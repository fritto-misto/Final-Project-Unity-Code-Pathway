using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Player // INHERITANCE
{
    private void Start()
    {
        base.shootRate = 0.5f;
        base.lives = 5;
    }
}
