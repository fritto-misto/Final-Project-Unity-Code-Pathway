using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerType { get; private set; }

    private int menuScene = 0;
    private int gameScene = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(Instance.gameObject);
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetPlayerType(string type)
    {
        playerType = type;
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
