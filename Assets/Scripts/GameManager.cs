using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Button wizardButton;
    public Button archerButton;

    public string playerType { get; private set; }

    private int menuScene = 0;
    private int gameScene = 1;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(menuScene);
    }
}
