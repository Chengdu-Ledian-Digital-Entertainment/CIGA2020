using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    /// <summary>
    /// 对象池内容
    /// </summary>
    GameObject item;
    /// <summary>
    /// 初始化函数
    /// </summary>
    Action<GameObject> foo;
    /// <summary>
    /// 初始化及扩容大小
    /// </summary>
    int baseAmount = 16;
    /// <summary>
    /// 对象池队列
    /// </summary>
    Queue<GameObject> pool;
    /// <summary>
    ///自身索引,用于扩容时绑定
    /// </summary>
    Pool mother;

    private void Awake()
    {
        pool = new Queue<GameObject>();
    }
    /// <summary>
    /// 构建对象池后调用的初始化函数
    /// </summary>
    public void Init(GameObject ob, Pool m, Action<GameObject> f = null)
    {
        mother = m;
        if (f == null)
        {
            Debug.LogWarning("对象池未设置初始化函数.", gameObject);
        }
        //保存引用,用于扩容
        foo = f;
        item = ob;

        AddItem();
    }
    /// <summary>
    /// 对象池增加物品
    /// </summary>
    void AddItem()
    {
        for(int i = 0; i < baseAmount; i++)
        {
            var ob = Instantiate(item, transform);
            foo?.Invoke(ob);
            ob.GetComponent<IProduct>().Mother = mother;
            ob.SetActive(false);
            pool.Enqueue(ob);
        }
    }
    /// <summary>
    /// 从对象池取出物体
    /// </summary>
    /// <returns></returns>
    public GameObject Get()
    {
        if (pool.Count <8)
        {
            AddItem();
        }
        return pool.Dequeue();
    }
    /// <summary>
    /// 将物体返回至对象池
    /// </summary>
    /// <param name="ob"></param>
    public void Return(GameObject ob)
    {
        ob.SetActive(false);
        pool.Enqueue(ob);
    }
}
/// <summary>
/// 对象池内容物接口
/// </summary>
public interface IProduct
{
    Pool Mother { get; set; }
}