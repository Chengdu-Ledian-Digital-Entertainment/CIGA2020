using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 补给箱
/// </summary>
public class Supply : MonoBehaviour
{
    [HideInInspector]
    public int bulletCount;
    private void Awake()
    {
        bulletCount = Random.Range(8, 15);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            var i = Random.Range(0, GM.instance.rifts.Length);
            Instantiate(GM.instance.rifts[i], transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
    }
    
}
