using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float speedMultiple = 1;

    Vector3 mouseWorldPosition;

    Vector2 move;
    [SerializeField]
    Rigidbody2D rb;

    private void Awake()
    {

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
        //transform.LookAt(mouseWorldPosition, Vector3.right);
        transform.up =mouseWorldPosition-transform.position;

        rb.velocity = move * speed * speedMultiple;
    }
}
