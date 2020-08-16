using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
/// <summary>
/// 补给箱
/// </summary>
public class Shiney : MonoBehaviour
{
    public Light2D point;
    /// <summary>
    /// 弹药补给数量
    /// </summary>
    [HideInInspector]
    public int bulletCount;
    /// <summary>
    /// 闪烁频率
    /// </summary>
    float shineyRate = 10f;
    float t;
    private void Awake()
    {
        shineyRate = Random.Range(2f, 10);
        bulletCount = Random.Range(3, 21);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            var i = Random.Range(0, GM.instance.rifts.Length);
            Instantiate(GM.instance.rifts[i], transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
    }
    

    private void Update()
    {
        t = Time.time % shineyRate;
        t = t > shineyRate / 2 ? (shineyRate - t) / shineyRate / 2f : t / shineyRate / 2f;
        point.intensity = t;
    }
}
