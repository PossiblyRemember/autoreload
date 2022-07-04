using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Guncomp : MonoBehaviour
{
    public static Guncomp inst = null;

    public bool doActivator = false;
   // void Main()
    //{ 
        
    //}

    
    void Awake()
    {
        ModAPI.Notify("AutoReloader Activated - this mod is brought to you by spira industries for only $12.99 and by looking at this you agree to our terms and services and now own the product, thanks for your purchase!");
    }
    void Update()
    {
        if (doActivator)
        {
            FirearmBehaviour[] guns = FindObjectsOfType<FirearmBehaviour>();
            foreach (FirearmBehaviour gun in guns)
            {
                Gunbeh AH = gun.gameObject.GetComponent<Gunbeh>();
                if (!AH)
                {
                    gun.gameObject.AddComponent<Gunbeh>();
                }
            }
        }
        //if (Input.GetKeyUp("h"))
        //{
            
        //}
    }
}
