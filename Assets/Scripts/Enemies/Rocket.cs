using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float Speed = 3;
    public float RotationSpeed = 3;

    private Transform _playerTransform;

    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    
    void Update()
    {
        Vector3 move = transform.position + transform.forward * Time.deltaTime * Speed;
        move.z = 0;
        transform.position = move;

        Vector3 ToPlayer = _playerTransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(ToPlayer, Vector3.forward);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation,Time.deltaTime * RotationSpeed);
    }
}
