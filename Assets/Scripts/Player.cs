using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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

        if (Input.GetKeyDown(KeyCode.UpArrow) && currPos != topLine)
        {
            Move(currLine + 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && currPos != bottomLine)
        {
            Move(currLine - 1);
        }
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
}
