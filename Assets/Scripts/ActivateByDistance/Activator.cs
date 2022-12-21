using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public Transform PlayerTransform ;
    public List<ActivateByDistance> ObjectsToActivate = new List<ActivateByDistance>();

    private void Awake()
    {
        PlayerTransform = FindObjectOfType<PlayerHealh>().transform;
    }
    void Update()
    {
        for (int i = 0; i < ObjectsToActivate.Count; i++)
        {

            ObjectsToActivate[i].CheckDistance(PlayerTransform.position);
            
        }
    }
    //private void Awake()
    //{
    //    foreach (var item in ObjectsToActivate)
    //    {
    //        var health = item.GetComponent<EnemiHealth>();
    //        if (health != null)
    //        {
    //            health.InitializeActivator(ObjectsToActivate);
    //        }
    //    }  
    //}
}
