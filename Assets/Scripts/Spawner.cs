using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    public GameObject ant;
    public Transform mainCamera;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI maxText;
    public int maxCount;
    public int count;

    public static int score;

    Pool enemyPool;

    public int levelTemp = 10;
    int rank=5;
    private void Awake()
    {
        instance = this;
        enemyPool = gameObject.AddComponent<Pool>();
    }
    private void OnEnable()
    {
        score = 0;
        scoreText.text = "0";
        maxText.text = "3";
        levelTemp = rank;
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
    //生成蚂蚁
    IEnumerator Spawn()
    {
        var ob = enemyPool.Get();

        Vector3 tempPosition = Vector3.zero;

        switch (Random.Range(0, 4))
        {
            //左边
            case 0:
                tempPosition.x = Random.Range(mainCamera.position.x - 20, mainCamera.position.x - 8);
                tempPosition.y = Random.Range(mainCamera.position.y - 10, mainCamera.position.y + 10);
                break;

            //右边
            case 1:
                tempPosition.x = Random.Range(mainCamera.position.x + 8, mainCamera.position.x + 20);
                tempPosition.y = Random.Range(mainCamera.position.y - 10, mainCamera.position.y + 10);
                break;
            //上边
            case 2:
                tempPosition.x = Random.Range(mainCamera.position.x - 16, mainCamera.position.x + 16);
                tempPosition.y = Random.Range(mainCamera.position.y + 5, mainCamera.position.y + 15);
                break;
            //下边
            case 3:
                tempPosition.x = Random.Range(mainCamera.position.x - 16, mainCamera.position.x + 16);
                tempPosition.y = Random.Range(mainCamera.position.y - 15, mainCamera.position.y - 5);
                break;
        }
        ob.transform.position = tempPosition;
        ob.SetActive(true);
        yield return null;
    }
    private void OnDisable()
    {
        if (score > PlayerPrefs.GetInt("High", 0))
            PlayerPrefs.SetInt("High", score);
    }
    public static void AddCore()
    {
        score++;
        instance.levelTemp--;
        if (instance.levelTemp == 0)
        {
            instance.maxCount++;
            instance.maxText.text = instance.maxCount.ToString();
            instance.levelTemp = instance.rank;
            instance.rank++; 
        }

        instance.scoreText.text = score.ToString();


    }

}
