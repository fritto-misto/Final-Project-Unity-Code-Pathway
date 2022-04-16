using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // ENCAPSULATION...
    public GameObject bullet;

    private const float leftBulletPos = 6f;

    private float delayTime = 0.3f;
    private float repeatRate;
    // ...ENCAPSULATION

    private void Start()
    {
        repeatRate = Random.Range(0.5f, 2f);
        InvokeRepeating(nameof(ShootBullet), delayTime, repeatRate);
    }

    protected void ShootBullet() // ABSTRACTION
    {
        Instantiate(bullet, new Vector3(leftBulletPos, transform.position.y, 0), bullet.transform.rotation);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FriendlyFire"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
