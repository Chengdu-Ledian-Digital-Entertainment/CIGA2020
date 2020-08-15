using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 地面移动(UV版本)
/// (暂时弃用)
/// </summary>
public class GroundMove : MonoBehaviour
{
    [SerializeField]
    Transform cam;
    [SerializeField]
    Material material;

    public Vector2 speed;
    private void Update()
    {
        material.mainTextureOffset = cam.position * speed;
    }

}
