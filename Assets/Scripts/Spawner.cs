using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    private GameManager gameManager;
    public GameObject wizardPrefab;
    public GameObject archerPrefab;

    private const float leftPlayerPos = -7.85f;
    private const float rightEnemyPos = 7.75f;

    private float delayTime = 1f;
    private float repeatRate = 1f;

    private const float topLine = 0.25f;
    private const float middleLine = -1.9f;
    private const float bottomLine = -4.05f;

    private float[] lines = new float[] { bottomLine, middleLine, topLine };

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), delayTime, repeatRate);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        GameObject player;
        if (gameManager.playerType == "Wizard")
        {
            player = wizardPrefab;
        }
        else
        {
            player = archerPrefab;
        }
        Instantiate(player, new Vector3(leftPlayerPos, middleLine, 0), player.transform.rotation);
    }

    void SpawnEnemy()
    {
        GameObject enemy = enemies[Random.Range(0, 2)];
        float yPos = lines[Random.Range(0, 3)];
        Instantiate(enemy, new Vector3(rightEnemyPos, yPos, 0), enemy.transform.rotation);
    }
}
