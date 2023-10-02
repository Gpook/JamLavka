using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void StartSceneTime()
    {
        Invoke(nameof(StartScene), 3f);
    }
    public void GameSceneTime()
    {
        Invoke(nameof(GameScene), 1f);
    }
    
    public void StartScene()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void GameScene()
    {
        SceneManager.LoadScene("Game");
    }
    
}
