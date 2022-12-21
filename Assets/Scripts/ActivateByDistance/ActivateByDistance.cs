using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
    public float DistanceToActivate = 20;
    private bool _isActive = true;
    public Activator Activator;

    private void Awake()
    {
        Activator = FindObjectOfType<Activator>();
    }
    private void Start()
    {
        Activator.ObjectsToActivate.Add(this);
    }
    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);
        if (_isActive)
        {
            if (distance > DistanceToActivate + 2)
            {
                Deactivate();
            }
        }
        else
        {
            if (distance < DistanceToActivate)
            {
                Activate();
            }
        }

    }

    public void Activate()
    {
        _isActive = true;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        Activator.ObjectsToActivate.Remove(this);
    }

#if UNITY_EDITOR

    private void OnDrawGizmosSelected ()
    {
        Handles.color = Color.gray;
        Handles.DrawWireDisc(transform.position, Vector3.forward, DistanceToActivate);
    }
#endif 

}
