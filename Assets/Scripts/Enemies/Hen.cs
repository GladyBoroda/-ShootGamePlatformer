using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    public Rigidbody Rigidbody;
    private Transform _playerTransform;
    public float Speed = 3;
    public float TimeToReachSpeed = 1;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void FixedUpdate()
    {
        if (_playerTransform == null) return;
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 Force = Rigidbody.mass * (toPlayer * Speed - Rigidbody.velocity) / TimeToReachSpeed;
        Rigidbody.AddForce(Force);
    }
}
