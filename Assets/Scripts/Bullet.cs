using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 子弹类
/// </summary>
public class Bullet : MonoBehaviour,IProduct
{
    public Pool Mother { get; set; }
    [HideInInspector]
    public BulletTemplate template;

    private void Update()
    {
        transform.Translate(Vector3.right * template.flySpeed * Time.deltaTime, Space.Self);
        if (Vector3.Distance(transform.position, PlayerController.player.transform.position) > 300)
            gameObject.SetActive(false);
    }
    //private void OnEnable()
    //{
    //    //GetComponentInChildren<TrailRenderer>().enabled = true;
    //}
    //private void OnBecameInvisible()
    //{
    //    gameObject.SetActive(false);
    //}
    private void OnDisable()
    {
        Mother.Return(gameObject);
    }

}
