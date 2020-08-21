using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSelf : MonoBehaviour
{
    public float t = 3f;
    private void OnEnable()
    {
        StartCoroutine(Fun());
    }
    IEnumerator Fun()
    {
        yield return new WaitForSeconds(t);
        Destroy(gameObject);
    }
}
