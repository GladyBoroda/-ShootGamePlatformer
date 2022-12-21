using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RopeState
{
    Disabled,
    Fly,
    Active
}

public class RopeGun : MonoBehaviour
{
    public Hook Hook;
    public Transform Spawn;
    public Transform RopeStart;
    public float Speed;
    public SpringJoint SpringJoint;
    public float SpringValue = 100;
    public float DamperValue = 5;
    public RopeRenderer RopeRenderer;
    public PlayerMove PlayerMove;

    private float _lengthRope;
    public RopeState CurrentRopeState;

    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Shot();
        }
        if (CurrentRopeState == RopeState.Fly)
        {
            float distanse = Vector3.Distance(RopeStart.position, Hook.transform.position);
            if (distanse>20)
            {
                Hook.gameObject.SetActive(false);
                CurrentRopeState = RopeState.Disabled;
                RopeRenderer.Hide();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CurrentRopeState == RopeState.Active)
            {
                if (PlayerMove.Grounded == false)
                {
                    PlayerMove.JumpPlayer();
                }
            }
            DestroySpring();

        }
        if (CurrentRopeState == RopeState.Fly || CurrentRopeState == RopeState.Active)
        {
            RopeRenderer.DrowRope(RopeStart.position, Hook.transform.position, _lengthRope);
        }
    }

    void Shot()
    {
        _lengthRope = 2;
        Hook.gameObject.SetActive(true);

        if (SpringJoint)
        {
            Destroy(SpringJoint);
        }

        Hook.StopFix();

        Hook.transform.position = Spawn.position;
        Hook.transform.rotation = Spawn.rotation;
        Hook.Rigidbody.velocity = Spawn.forward * Speed;

        CurrentRopeState = RopeState.Fly;
    }
    public void CreateSpring()
    {
        if (SpringJoint == null)
        {
            SpringJoint = gameObject.AddComponent<SpringJoint>();
            SpringJoint.connectedBody = Hook.Rigidbody;
            SpringJoint.anchor = RopeStart.localPosition;
            SpringJoint.autoConfigureConnectedAnchor = false;
            SpringJoint.connectedAnchor = Vector3.zero;
            SpringJoint.spring = SpringValue;
            SpringJoint.damper = DamperValue;

            _lengthRope = Vector3.Distance(RopeStart.position, Hook.transform.position);
            SpringJoint.maxDistance = _lengthRope;
            CurrentRopeState = RopeState.Active;
        }
    }
    public void DestroySpring()
    {
        if (SpringJoint)
        {
            Destroy(SpringJoint);
            CurrentRopeState = RopeState.Disabled;
            Hook.gameObject.SetActive(false);
            RopeRenderer.Hide();
        }
    }
}
