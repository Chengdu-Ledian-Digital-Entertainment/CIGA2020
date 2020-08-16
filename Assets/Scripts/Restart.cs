using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 重启游戏
/// </summary>
public class Restart : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1);
        }
    }
}
