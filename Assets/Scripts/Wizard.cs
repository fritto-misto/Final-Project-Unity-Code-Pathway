using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Player
{
    private void Start()
    {
        base.shootRate = 0.5f;
        base.lives = 5;
    }
}
