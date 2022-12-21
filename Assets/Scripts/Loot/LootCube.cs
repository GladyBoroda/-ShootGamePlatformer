using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootCube : MonoBehaviour
{
    public float DurationPanch = 2;
    public int VibrattoPanch = 2;
    public float ElasticityPanch = 0.5f;
    public float ScaleTime = 2;
    public GameObject Cube;
    public GameObject PrefabsLootFromCube;
    public GameObject TransformLoot;

    IEnumerator ScaleProcess()
    {

        {
            Cube.transform.DOPunchPosition(Vector3.up, DurationPanch, VibrattoPanch, ElasticityPanch);
            yield return new WaitForSeconds(ScaleTime);
            
            Destroy(gameObject);
            yield return null;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<PlayerHealh>())
            {
                StartCoroutine(ScaleProcess());
                enabled = false;    
                Instantiate(PrefabsLootFromCube,TransformLoot.transform.position, Quaternion.identity);



            }
        }
            
    }
}

