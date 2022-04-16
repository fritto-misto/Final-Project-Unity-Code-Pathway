using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // ENCAPSULATION...
    public GameObject bullet;
    protected int lives;
    protected float shootRate;

    private bool canShoot = true;

    private const float leftPlayerPos = -7.85f;
    private const float leftBulletPos = -6.43f;

    private const float topLine = 0.25f;
    private const float middleLine = -1.9f;
    private const float bottomLine = -4.05f;

    private float[] lines = new float[] { bottomLine, middleLine, topLine };
    // ...ENCAPSULATION

    void Start()
    {
        transform.position = GetSpawnPos(); // ABSTRACTION
    }

    protected virtual void Update()
    {
        float currPos = transform.position.y;
        int currLine = GetCurrentPosition(); // ABSTRACTION

        if (lives < 1)
        {
            GameOver(); // ABSTRACTION
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && currPos != topLine)
        {
            Move(currLine + 1); // ABSTRACTION
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && currPos != bottomLine)
        {
            Move(currLine - 1); // ABSTRACTION
        }
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            canShoot = false;
            StartCoroutine(ShootCountdown());
            ShootBullet(bullet); // ABSTRACTION
        }
    }

    IEnumerator ShootCountdown()
    {
        yield return new WaitForSeconds(shootRate);
        canShoot = true;
    }

    public Vector3 GetSpawnPos() // ABSTRACTION
    {
        return new Vector3(leftPlayerPos, middleLine, 0);
    }

    int GetCurrentPosition() // ABSTRACTION
    {
        int currPosIndex;
        switch (transform.position.y)
        {
            case topLine:
                currPosIndex = 2;
                break;
            case middleLine:
                currPosIndex = 1;
                break;
            default:
                currPosIndex = 0;
                break;
        }
        return currPosIndex;
    }

    void Move(float nextPos) // POLYMORPHISM // ABSTRACTION
    {
        transform.position = new Vector3(leftPlayerPos, nextPos, 0);
    }

    void Move(int nextPosIndex) // POLYMORPHISM // ABSTRACTION
    {
        transform.position = new Vector3(leftPlayerPos, lines[nextPosIndex], 0);
    }

    protected void ShootBullet(GameObject bullet) // ABSTRACTION
    {
        Instantiate(bullet, new Vector3(leftBulletPos, transform.position.y, 0), bullet.transform.rotation);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyFire"))
        {
            UpdateLives(-1); // ABSTRACTION
            Destroy(collision.gameObject);
        }
    }

    void UpdateLives(int livesToAdd) // ABSTRACTION
    {
        lives -= livesToAdd;
        //change displayed number on canvas
    }

    void GameOver() // ABSTRACTION
    {
        Debug.Log("Game Over");
    }
}
