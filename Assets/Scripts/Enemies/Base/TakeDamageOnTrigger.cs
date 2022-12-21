using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    public EnemiHealth EnemiHealth;

    public bool DieOnEnyCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>())
        {
            EnemiHealth.TakeDamage(1);
            
        }

        if (DieOnEnyCollision == true)
        {
            if (other.isTrigger == false)
            {
                EnemiHealth.TakeDamage(10000);
            }
            
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.rigidbody)
    //    {
    //        if (collision.rigidbody.GetComponent<Bullet>())
    //        {
    //            EnemiHealth.TakeDamage(1);
    //        }
    //    }
    //    if (DieOnEnyCollision == true)
    //    {
    //        EnemiHealth.TakeDamage(10000);
    //    }

    //}
}
