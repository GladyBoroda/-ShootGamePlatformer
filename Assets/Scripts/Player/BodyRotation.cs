using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRotation : MonoBehaviour
{
    public Camera Camera;
    public Transform Aim;
    public float RotationSpeed;
    public float AngleRotation= 45;

    

    void Update()
    {
        if (Input.mousePosition.x >= Camera.WorldToScreenPoint(transform.position).x)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -45, 0), Time.deltaTime * RotationSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 45, 0), Time.deltaTime * RotationSpeed);
        }
        //float angleY = Aim.position.x < transform.position.x ? AngleRotation : -AngleRotation;
        //transform.rotation = Quaternion.Lerp(transform.rotation,
        //    Quaternion.Euler(0, angleY, 0),
        //    Time.deltaTime * RotationSpeed);
    } 
}
