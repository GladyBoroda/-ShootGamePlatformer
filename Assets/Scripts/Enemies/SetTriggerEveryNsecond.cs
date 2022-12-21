using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriggerEveryNsecond : MonoBehaviour
{
    public float Period = 7;
    public Animator Animator;
    private float _timer;

    public string TriggerName = "Attack";

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer>Period)
        {
            _timer = 0;
            Animator.SetTrigger(TriggerName);
        }
    }
}
