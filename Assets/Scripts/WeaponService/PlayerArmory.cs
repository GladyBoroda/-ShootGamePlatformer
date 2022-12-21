using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    public Gun[] Guns;
    public int CurrentGunIndex;

    void Start()
    {
        TakeGunByIndex(CurrentGunIndex);
    }

    public void TakeGunByIndex(int gunIndex)
    {
        CurrentGunIndex = gunIndex;
        for (int i = 0; i < Guns.Length; i++)
        {
            if (i == gunIndex)
            {
                Guns[i].Activate();
            }
            else
            {
                Guns[i].Deactivate();
            }
        }
    }

    public void AddBullets(int gunIndex, int numberOfBullets)
    {
        Guns[gunIndex].AddBullets(numberOfBullets);
    }

    
}
