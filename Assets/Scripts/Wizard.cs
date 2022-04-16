using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Player
{
    public GameObject fireball;

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet(fireball);
        }
    }
}
