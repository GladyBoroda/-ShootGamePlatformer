using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float Duration;
    public float Strenght;
    public int Vibrato;
    public float Randomnes;
    public float _timer;

    void Awake()
    {

    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 1)
        {

            _timer = 0;
            transform.DOShakeScale(Duration, Strenght, Vibrato, Randomnes);

        }
    }
}
