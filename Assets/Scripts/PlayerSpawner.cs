using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject wizardPrefab;
    public GameObject archerPrefab;

    private const float leftPlayerPos = -7.85f;
    private const float middleLine = -1.9f;

    // Start is called before the first frame update
    void Start()
    {
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
}
