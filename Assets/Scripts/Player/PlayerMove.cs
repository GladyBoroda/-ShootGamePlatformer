using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float SpeedMove = 2;
    public float JumpSpeed;
    public float Friction;
    public bool Grounded;
    public Transform CollederTransform;
    private int _jumpFrameCounter;

    public float MaxSpeed;

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || Grounded == false)
        {
            CollederTransform.localScale = Vector3.Lerp(CollederTransform.localScale, new Vector3(1, 0.5f, 1), Time.deltaTime * 10);
        }
        else
        {
            CollederTransform.localScale = Vector3.Lerp(CollederTransform.localScale, new Vector3(1, 1, 1), Time.deltaTime * 10);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Grounded)
            {
                JumpPlayer();
            }

        }
    }

    public void JumpPlayer()
    {
        _jumpFrameCounter = 0;
        Rigidbody.AddForce(0, JumpSpeed, 0, ForceMode.VelocityChange);
    }

    private void FixedUpdate()
    {
        Rigidbody.AddForce(0,0,0, ForceMode.VelocityChange);

        float speedMultiplier = 1;

        if (Grounded == false)
        {
            speedMultiplier = 0.2f;

            if (Rigidbody.velocity.x > MaxSpeed && Input.GetAxis("Horizontal") > 0)
            {
                speedMultiplier = 0;
            }
            if (Rigidbody.velocity.x < -MaxSpeed && Input.GetAxis("Horizontal") < 0)
            {
                speedMultiplier = 0;
            }
        }



        Rigidbody.AddForce(Input.GetAxis("Horizontal") * SpeedMove * speedMultiplier, 0, 0, ForceMode.VelocityChange);
        if (Grounded)
        {
            Rigidbody.AddForce(-Rigidbody.velocity.x * Friction, 0, 0, ForceMode.VelocityChange);

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 15);
        }

        _jumpFrameCounter += 1;
        if (_jumpFrameCounter == 2)
        {
            Rigidbody.freezeRotation = false;
            Rigidbody.AddRelativeTorque(0, 0, 20, ForceMode.VelocityChange);
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);
        if (angle < 45)
        {
            Grounded = true;
            Rigidbody.freezeRotation = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Grounded = false;
        
    }
}
