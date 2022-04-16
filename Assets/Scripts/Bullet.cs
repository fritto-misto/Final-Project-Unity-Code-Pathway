using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected virtual float speed { get; set; } // ENCAPSULATION
    private float xBound = 10.0f;

    protected virtual void Update()
    {
        Move(); // ABSTRACTION
        DestroyOutOfBounds(); // ABSTRACTION
    }

    void Move() // ABSTRACTION
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void DestroyOutOfBounds() // ABSTRACTION
    {
        if (transform.position.x > xBound || transform.position.x < -xBound)
        {
            Destroy(gameObject);
        }
    }
}
