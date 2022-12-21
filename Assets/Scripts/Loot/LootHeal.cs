using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHeal : MonoBehaviour
{
    public int HealthValue = 1;

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealh>())
        {
            collision.gameObject.GetComponent<PlayerHealh>().AddHealh(HealthValue);
            Destroy(gameObject);
        }
    }
}
