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
    public GameObject ant;//蚂蚁
    public GameObject supply;//补给箱

    private void Awake()
    {
        instance = this;


    }
}
