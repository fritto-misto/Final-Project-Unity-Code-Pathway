using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet // INHERITANCE
{
    void Start()
    {
        base.speed = 20.0f;
    }

    protected override void Update() // POLYMORPHISM
    {
        base.Update();
        //do something else
    }
}
