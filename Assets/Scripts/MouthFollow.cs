using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
/// <summary>
/// 手电筒类
/// </summary>
public class MouthFollow : MonoBehaviour
{
    /// <summary>
    /// 锥形光
    /// </summary>
    public Light2D lightRoad;
    /// <summary>
    /// 圆形光
    /// </summary>
    public Light2D circleLight;

    void Update()
    {
        transform.position = PlayerController.instance.mouseWorldPosition;

        lightRoad.pointLightOuterAngle = Mathf.Rad2Deg * Mathf.Atan((circleLight.pointLightOuterRadius + 1) / Vector3.Distance(transform.position, PlayerController.player.transform.position)) * 2;
        lightRoad.pointLightOuterRadius = Vector3.Distance(transform.position, PlayerController.player.transform.position);
    }
}
