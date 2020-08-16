using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShooting : MonoBehaviour
{

    public bool isHoldingTrigger;
    public Transform shotPoint;
    public Gun gun;
    public GameObject bullet;
    [Header("子弹UI")]
    public TextMeshProUGUI text;
    /// <summary>
    /// 子弹数量
    /// </summary>
    public int bulletCount;

    /// <summary>
    /// 弹夹(子弹对象池)
    /// </summary>
    Pool bulletClip;
    Vector3 dir;

    float d;//每帧时间的缓存
    private void Awake()
    {
        bulletClip = gameObject.AddComponent<Pool>();
        bulletClip.Init(bullet, bulletClip);
    }

    private void Update()
    {
        d = Time.deltaTime;
        dir = PlayerController.instance.mouseWorldPosition - shotPoint.position;

        gun?.Cooldown(d);
        isHoldingTrigger = Input.GetMouseButton(0);

        if (isHoldingTrigger)
        {
            gun?.Shot(bulletClip, dir, shotPoint.position, ref bulletCount);
        }
        text.text = bulletCount.ToString();
    }

}
