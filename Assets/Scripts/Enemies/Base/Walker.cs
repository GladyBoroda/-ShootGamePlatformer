using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left = 0,
    Right = 1
}

public class Walker : MonoBehaviour
{
    public Transform LeftTarget;
    public Transform RightTarget;
    public Transform RayStart;

    public float Speed = 2;
    public float StopTime = 2;

    private bool _isStop;

    public Direction CurrentDirection;
    public UnityEvent EventOnLeftTarget;
    public UnityEvent EventOnRightTarget;

    public void Start()
    {
        LeftTarget.parent = null;
        RightTarget.parent = null;
    }
    
    void ContinueWalk()
    {
        _isStop = false;
    }


    void Update()
    {
        if (_isStop == true)
        {
            return;
        }
        if (CurrentDirection == Direction.Left)
        {
            transform.position -= new Vector3(Speed * Time.deltaTime, 0, 0);

            if (transform.position.x < LeftTarget.position.x)
            {
                CurrentDirection = Direction.Right;
                _isStop = true;
                Invoke(nameof(ContinueWalk), StopTime);
                EventOnLeftTarget.Invoke();
            }

        }
        else
        {
            transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);

            if (transform.position.x > RightTarget.position.x)
            {
                CurrentDirection = Direction.Left;
                _isStop = true;
                Invoke(nameof(ContinueWalk), StopTime);
                EventOnRightTarget.Invoke();
            }

        }
        RaycastHit hit;
        if (Physics.Raycast(RayStart.position, Vector3.down, out hit))
        {
            transform.position = hit.point;
        }

    }
}
