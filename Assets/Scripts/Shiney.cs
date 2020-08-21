using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
/// <summary>
/// 闪烁
/// </summary>
public class Shiney : MonoBehaviour
{
    public Light2D point;
    public float multiple = 1;
    /// <summary>
    /// 闪烁频率
    /// </summary>
    float shineyRate = 10f;
    float t;
    private void Awake()
    {
        //shineyRate = Random.Range(2f, 10);
    }
    private void Update()
    {
        //t = Time.time % shineyRate;
        //t = t > shineyRate / 2 ? (shineyRate - t) / shineyRate / 2f : t / shineyRate / 2f;
        t = Mathf.Cos(Time.time);
        
        point.intensity = (t+1)*multiple;
    }
}
