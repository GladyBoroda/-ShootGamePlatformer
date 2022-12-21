using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Automat : Gun
{
    [Header("Automat")]
    public int NumberOfBullets;
    public TextMeshProUGUI BulletText;
    public PlayerArmory PlayerArmory;

    public override void Shoot()
    {
        base.Shoot();
        NumberOfBullets -= 1;
        UpdateText();
        if (NumberOfBullets == 0)
        {
            PlayerArmory.TakeGunByIndex(0);
        }
        
    }

    public override void Activate()
    {
        base.Activate();
        BulletText.enabled = true;
        UpdateText();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        BulletText.enabled=false;
    }

    public void UpdateText()
    {
        BulletText.text = NumberOfBullets.ToString();
    }

    public override void AddBullets(int numberOfBullet)
    {
        base.AddBullets(numberOfBullet);
        NumberOfBullets+=numberOfBullet;
        UpdateText();
        PlayerArmory.TakeGunByIndex(1);
    }
}
