using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 蚂蚁类
/// </summary>
public class Enemy : MonoBehaviour, IProduct
{

    public int hp;
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

    public Pool Mother { get; set; }

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
            collision.gameObject.SetActive(false);

            if (hp <= 0)
                Death();
        }
    }

    private void Update()
    {
        MoveToPlayer();
    }
    private void OnEnable()
    {
        hp = Random.Range(3, 6);
    }

    private void OnDisable()
    {
        if (Mother.gameObject.GetComponent<Spawner>().count > 0)
            Mother.gameObject.GetComponent<Spawner>().count--;

        //print(GetHashCode() + "隐身!");
        Mother.Return(gameObject);
    }

    public void MoveToPlayer()
    {
        dir = player.position - transform.position;
        transform.up = dir;
        transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);
    }
    void Death()
    {
        Instantiate(GM.instance.supply, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
