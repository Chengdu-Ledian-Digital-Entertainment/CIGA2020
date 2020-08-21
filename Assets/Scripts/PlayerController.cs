using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家控制器
/// </summary>
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float speedMultiple = 1;
    public static PlayerController instance;
    public Vector3 mouseWorldPosition;
    public static GameObject player;

    public GameObject deathIcon;
    /// <summary>
    /// 地面
    /// </summary>
    public Transform ground;
    public Camera mainCamera;
    public static Animator animator;
    public AudioClip deathAudio;
    Vector2 move;
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    PlayerShooting shoot;
    private void Awake()
    {
        instance = this;
        player = gameObject;
        animator = GetComponent<Animator>();
    }
    void Start()
    {

    }

    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;

        transform.up = mouseWorldPosition - transform.position;

        rb.velocity = move.normalized * speed * speedMultiple;

        animator.SetFloat("Speed", rb.velocity.magnitude);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Damage"))
        {
            Death();
        }
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
                shoot.bulletCount += collision.GetComponent<Supply>().bulletCount;
                Destroy(collision.gameObject);
                break;
        }
    }
    void Death()
    {
        print("死亡");
        animator.SetBool("Death", true);
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(deathAudio);
        deathIcon.SetActive(true);
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Static;
        mouseWorldPosition = transform.position;
        gameObject.GetComponent<PlayerShooting>().enabled = false;
        enabled = false;
        //gameObject.SetActive(false);
    }
}
