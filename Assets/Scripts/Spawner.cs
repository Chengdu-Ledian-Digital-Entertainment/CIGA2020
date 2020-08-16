﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ant;
    public Transform mainCamera;
    public int maxCount;
    public int count;

    Pool enemyPool;
    private void Awake()
    {
        enemyPool = gameObject.AddComponent<Pool>();
    }
    private void Start()
    {

        enemyPool.Init(ant, enemyPool);
    }
    private void Update()
    {
        if (count < maxCount)
        {
            count++;
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        var ob = enemyPool.Get();

        Vector3 tempPosition = Vector3.zero;

        switch (Random.Range(0, 4))
        {
            case 0:
                tempPosition.x = Random.Range(mainCamera.position.x - 20, mainCamera.position.x - 16);
                tempPosition.y = Random.Range(mainCamera.position.y - 10, mainCamera.position.y + 10);
                break;
            case 1:
                tempPosition.x = Random.Range(mainCamera.position.x + 16, mainCamera.position.x + 20);
                tempPosition.y = Random.Range(mainCamera.position.y - 10, mainCamera.position.y + 10);
                break;
            case 2:
                tempPosition.x = Random.Range(mainCamera.position.x - 16, mainCamera.position.x + 16);
                tempPosition.y = Random.Range(mainCamera.position.y + 10, mainCamera.position.y + 15);
                break;
            case 3:
                tempPosition.x = Random.Range(mainCamera.position.x - 16, mainCamera.position.x + 16);
                tempPosition.y = Random.Range(mainCamera.position.y - 15, mainCamera.position.y - 10);
                break;
        }
        ob.transform.position = tempPosition;
        ob.SetActive(true);
        yield return null;
    }

}