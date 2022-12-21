using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGun : MonoBehaviour
{
    public Rigidbody PlayerRigidbody;
    public float Speed;
    public Transform Spawn;
    public Gun Pistol;

    public float MaxChargeJump;
    private float _currentChargeJump;
    private bool _isCharged;

    public ChargeJumpIcon ChargeJumpIcon;

    private void Update()
    {
        if (_isCharged)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                PlayerRigidbody.AddForce(-Spawn.forward * Speed, ForceMode.VelocityChange);
                Pistol.Shoot();
                _isCharged = false;
                _currentChargeJump = 0;
                ChargeJumpIcon.StartCharge();
            }
        }
        else
        {
            _currentChargeJump += Time.deltaTime;
            ChargeJumpIcon.SetChargeValue( _currentChargeJump, MaxChargeJump);
            if (_currentChargeJump >= MaxChargeJump )
            {
                _isCharged = true;
                ChargeJumpIcon.StopCharge();
            }
        }
    }
}
