﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家控制器
/// </summary>
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float speedMultiple = 1;

    public static Vector3 mouseWorldPosition;
    public static GameObject player;

    /// <summary>
    /// 地面
    /// </summary>
    public Transform ground;

    Vector2 move;
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    PlayerShooting shoot;
    private void Awake()
    {
        player = gameObject;
    }
    void Start()
    {

    }

    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        transform.up = mouseWorldPosition - transform.position;

        rb.velocity = move.normalized * speed * speedMultiple;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            //地面移动
            case "Wall":
                switch (collision.name)
                {
                    case "North":
                        ground.position += Vector3.up * 9.8983f;
                        break;
                    case "South":
                        ground.position += Vector3.down * 9.8983f;
                        break;
                    case "East":
                        ground.position += Vector3.left * 16;
                        break;
                    case "West":
                        ground.position += Vector3.right * 16;
                        break;
                }
                break;
                //拾取补给
            case "Supply":
                shoot.bulletCount += collision.GetComponent<Shiney>().bulletCount;
                Destroy(collision.gameObject);
                break;
        }


    }
}
