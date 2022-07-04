using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gunbeh : FirearmBehaviour
{
    public bool defaultBulletsb = true;
    private int DefaultBullets = 6;
    private int Bullets = 0;
    private object Gun = Get
    void Update()
    {
        if(defaultBulletsb == true)
        {
            Bullets = DefaultBullets;
        }
        Gun.FirearmBehaviour.OnFire
        {
            Bullets -- Bullets - 1;
        }
        if (default == 0)
        {
            FireDelay = 7;
            DefaultBullets = 
        }
    }
}