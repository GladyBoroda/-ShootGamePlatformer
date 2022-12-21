using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTargetEuler : MonoBehaviour
{
    public Vector3 LeftEuler;
    public Vector3 RightEuler;
    public float RotationSpeed = 2;

    private Vector3 _targetEuler;

    public void RotateLeft()
    {
        _targetEuler = LeftEuler;
    }
    public void RotateRight()
    {
        _targetEuler = RightEuler;
    }

    void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(_targetEuler), Time.deltaTime * RotationSpeed);
    }
}
