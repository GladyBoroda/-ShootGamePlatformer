using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatchPrefabCreator : MonoBehaviour
{
    public GameObject Prefabs;
    public Transform[] Spawn;

    [ContextMenu("Create")]
    public void Create()
    {
        for (int i = 0; i < Spawn.Length; i++)
        {
            Instantiate(Prefabs, Spawn[i].position, Spawn[i].rotation);
        }
    }
}
