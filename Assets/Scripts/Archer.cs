using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Player
{
    private void Start()
    {
        base.shootRate = 0.25f;
        base.lives = 3;
    }
}
