using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    void Start()
    {
        base.speed = 20.0f;
    }

    protected override void Update()
    {
        base.Update();
    }
}
