using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Player
{
    public GameObject arrow;

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet(arrow);
        }
    }
}
