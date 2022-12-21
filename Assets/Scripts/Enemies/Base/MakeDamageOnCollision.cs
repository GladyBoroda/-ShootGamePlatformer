using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnCollision : MonoBehaviour
{
    public int DamageValue = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<PlayerHealh>())
            {
                collision.rigidbody.GetComponent<PlayerHealh>().TakeDamage(DamageValue);
            }
        }
        
    }

    
}
