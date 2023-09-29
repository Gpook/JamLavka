using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void StartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void GameScene()
    {
        SceneManager.LoadScene("Game");
    }
}
