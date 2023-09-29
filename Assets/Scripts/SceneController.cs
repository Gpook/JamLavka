using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void StartSceneTime()
    {
        Invoke(nameof(StartScene), 2f);
    }
    public void GameSceneTime()
    {
        Invoke(nameof(GameScene), 2f);
    }
    
    private void StartScene()
    {
        SceneManager.LoadScene("Menu");
    }
    
    private void GameScene()
    {
        SceneManager.LoadScene("Game");
    }
}
