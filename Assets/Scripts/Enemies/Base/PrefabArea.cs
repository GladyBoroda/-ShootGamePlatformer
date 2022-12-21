using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrefabArea : MonoBehaviour
{
    [SerializeField] private EnemiHealth[] _enemies;
    [SerializeField] private float _distansToShow = 20;
    public Transform PlayerTransform;

    public void Start()
    {
        _enemies = FindObjectsOfType<EnemiHealth>();
        for (int i = 0; i < _enemies.Length; i++)
        {
            SetEnemyActive(i, false);
        }
        
    }

    void Update()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            
            if (_enemies[i])
            {
                if (_enemies[i].transform.position.x < PlayerTransform.position.x + _distansToShow)
                {
                    SetEnemyActive(i, true);
                }
                else
                {
                    SetEnemyActive(i,false);
                }
            }
            
            
        }
    }

    private void SetEnemyActive(int id, bool value)
    {
        _enemies[id].gameObject.SetActive(value);
    }
}
