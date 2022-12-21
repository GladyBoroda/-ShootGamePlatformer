using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    public EnemiHealth EnemiHealth;
    public bool DieOnEnyCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<Bullet>())
            {
                EnemiHealth.TakeDamage(1);
            }
        }
        if (DieOnEnyCollision==true)
        {
            EnemiHealth.TakeDamage(10000);
        }
        
    }
}
