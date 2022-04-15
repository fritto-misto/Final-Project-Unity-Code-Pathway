using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Button wizardButton;
    private Button archerButton;

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

        wizardButton = GameObject.Find("Wizard Button").GetComponent<Button>();
        archerButton = GameObject.Find("Archer Button").GetComponent<Button>();

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
