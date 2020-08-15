using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 蚂蚁类
/// </summary>
public class Enemy : MonoBehaviour
{
    [SerializeField]
    int hp;
    /// <summary>
    /// 玩家引用
    /// </summary>
    Transform player;
    /// <summary>
    /// 朝向玩家的方向
    /// </summary>
    [SerializeField]
    Vector3 dir;

    /// <summary>
    /// 移动速度
    /// </summary>
    [SerializeField]
    float speed;
    void Start()
    {
        player = PlayerController.player.transform;
        speed = Random.Range(1, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            hp -= collision.GetComponent<Bullet>().template.damage;
            if (hp <= 0)
                Death();
        }
    }

    private void Update()
    {
        MoveToPlayer();
    }
    private void OnDisable()
    {

    }

    void MoveToPlayer()
    {
        dir = player.position - transform.position;
        transform.up = dir;
        transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);
    }
    void Death()
    {
        var i = Random.Range(0, GM.instance.rifts.Length);
        Instantiate(GM.instance.rifts[i], transform.position, Quaternion.identity);

        gameObject.SetActive(false);
    }
}
