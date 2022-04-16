using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected virtual float speed { get; set; }
    private float xBound = 10.0f;

    protected virtual void Update()
    {
        Move();
        DestroyOutOfBounds();
    }

    void Move()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void DestroyOutOfBounds()
    {
        if (transform.position.x > xBound || transform.position.x < -xBound)
        {
            Destroy(gameObject);
        }
    }
}
