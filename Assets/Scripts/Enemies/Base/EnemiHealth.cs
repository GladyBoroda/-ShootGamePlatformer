using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiHealth : MonoBehaviour
{
    public int Health = 1;
    public UnityEvent EventOnTakeDamage;
    public UnityEvent EventOnDie;


    public void TakeDamage(int damageValue)
    {
        Health -= damageValue;
        if (Health <= 0)
        {
            Die();
        }
        EventOnTakeDamage.Invoke();
    }

    public void Die()
    {
        EventOnDie.Invoke();
        Destroy(gameObject);
    }


}
