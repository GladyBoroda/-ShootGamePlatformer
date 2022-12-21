using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootAmmo : MonoBehaviour
{
    // пробовал сам реализовать логику подбора пуль, до просмотра курса.



    //public int AmmoValue = 10;
    //public GunShot GunShot;

    //public void Awake()
    //{
    //    GunShot = FindObjectOfType<GunShot>();
    //}

    //private void OnCollisionEnter(Collision collision)
    //{

    //    PlayerHealh player = collision.gameObject.GetComponent<PlayerHealh>();
    //    if (player)
    //    {
    //        GunShot.AddAmmo(AmmoValue);
    //        Destroy(gameObject);
    //    }
    //}
    public int GunIndex;
    public int NumberOfBullets;

    private void OnTriggerEnter (Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerArmory>())
        {
            other.attachedRigidbody.GetComponent<PlayerArmory>().AddBullets(GunIndex,NumberOfBullets);
            Destroy(gameObject);
        }
    }
}
