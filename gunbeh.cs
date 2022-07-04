using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gunbeh : FirearmBehaviour
{
    public bool defaultBulletsb = true;
    private int DefaultBullets = 6;
    private int Bullets = 0;
    [SerializeField] private float _time = 7f;

    void Update()
    {
        if (defaultBulletsb == true)
        {
            Bullets = DefaultBullets;
        }
        GetComponent<UseEventTrigger>().Action = () =>
        {
            Bullets--;
            ModAPI.Notify("You have " + Bullets + "left!");
        };
        if (default == 0)
        {
            this.BulletsPerShot = 0;
            Invoke("ResetBullet", _time);
        }
    }
    public void ResetBullet()
    {
        Bullets = DefaultBullets;
        this.BulletsPerShot = 0;
    }
}