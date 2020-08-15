using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
