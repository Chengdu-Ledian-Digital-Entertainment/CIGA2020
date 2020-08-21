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

    Animator animator;
    public GameObject atkBox;
    public Pool Mother { get; set; }

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    void Start()
    {
        player = PlayerController.player.transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Attack");
        }
        if (collision.collider.CompareTag("Bullet"))
        {
            hp -= collision.collider.GetComponent<Bullet>().template.damage;
            collision.gameObject.SetActive(false);

            if (hp <= 0)
                Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            animator.SetBool("Find", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("Find", false);

        }
    }

    private void Update()
    {
        //MoveToPlayer();
        if (Vector3.Distance(transform.position, PlayerController.player.transform.position) > 40)
            gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        hp = Random.Range(3, 7);
        speed = Random.Range(2.5f,5);

    }

    private void OnDisable()
    {
        if (Mother.gameObject.GetComponent<Spawner>().count > 0)
            Mother.gameObject.GetComponent<Spawner>().count--;
        Instantiate(GM.instance.enemyDeathAudio, transform.position, Quaternion.identity);
        atkBox.SetActive(false);
        //print(GetHashCode() + "隐身!");
        Mother.Return(gameObject);
    }

    public void MoveToPlayer()
    {

        dir = player.position - transform.position;
        transform.up = dir;
        speed = Random.Range(4,10f);

        transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);

    }
    void Death()
    {
        Instantiate(GM.instance.supply, transform.position, Quaternion.identity);
        Spawner.AddCore();
        gameObject.SetActive(false);
    }
}
