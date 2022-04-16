using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public TextMeshPro livesText;

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

    // Start is called before the first frame update
    void Start()
    {
        transform.position = GetSpawnPos();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        float currPos = transform.position.y;
        int currLine = GetCurrentPosition();

        if (lives < 1)
        {
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && currPos != topLine)
        {
            Move(currLine + 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && currPos != bottomLine)
        {
            Move(currLine - 1);
        }
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            canShoot = false;
            StartCoroutine(ShootCountdown());
            ShootBullet(bullet);
        }
    }

    IEnumerator ShootCountdown()
    {
        yield return new WaitForSeconds(shootRate);
        canShoot = true;
    }

    public Vector3 GetSpawnPos()
    {
        return new Vector3(leftPlayerPos, middleLine, 0);
    }

    int GetCurrentPosition()
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

    void Move(float nextPos)
    {
        transform.position = new Vector3(leftPlayerPos, nextPos, 0);
    }

    void Move(int nextPosIndex)
    {
        transform.position = new Vector3(leftPlayerPos, lines[nextPosIndex], 0);
    }

    protected void ShootBullet(GameObject bullet)
    {
        Instantiate(bullet, new Vector3(leftBulletPos, transform.position.y, 0), bullet.transform.rotation);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyFire"))
        {
            UpdateLives(-1);
            Destroy(collision.gameObject);
        }
    }

    void UpdateLives(int livesToAdd)
    {
        lives -= livesToAdd;
        livesText.text = "Lives: " + lives;
    }

    void GameOver()
    {
        Debug.Log("Game Over");
    }
}
