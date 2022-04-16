using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet // INHERITANCE
{
    void Start()
    {
        base.speed = -15.0f;
    }

    protected override void Update() // POLYMORPHISM
    {
        base.Update();
        //do something else
    }
}
