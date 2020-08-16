using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 存放引用的工具人
/// </summary>
public class GM : MonoBehaviour
{
    public static GM instance;

    /// <summary>
    /// 地图障碍物
    /// </summary>
    public GameObject[] rifts;
    public GameObject[] jj;//家具
    public GameObject ant;//蚂蚁
    public GameObject supply;//补给箱
    public LayerMask m;
    public int jjCount = 200;

    Vector3 p;

    private void Awake()
    {
        instance = this;
        StartCoroutine(SpawnJJ());

    }

    //生成家具
    IEnumerator SpawnJJ()
    {
        while (jjCount > 0)
        {
            p.x = Random.Range(-50f, 50f);
            p.y = Random.Range(-50f, 50f);

            if(!Physics2D.CircleCast(p, 2, Vector2.one,1,m).collider)
            {
                Instantiate(jj[Random.Range(0,jj.Length)],p,Quaternion.identity);
                jjCount--;
            }
            else
            {
                print(Physics2D.CircleCast(p, 2, Vector2.one,1,m).collider);
            }
            yield return new WaitForSeconds(.1f);
        }
    }

}
