using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapManager : MonoBehaviour
{
    private int menuScene = 0;
    private int gameScene = 1;

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(menuScene);
    }
}
