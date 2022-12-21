using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public LevelService LevelService;
    public UiService UiService;
    public Canvas CanvasMenu;

    private void Awake()
    {
        LevelService = FindObjectOfType<LevelService>();
        UiService = FindObjectOfType<UiService>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.GetComponent<PlayerHealh>() )
        {
            UiService.Finish();
            Debug.Log("1");
            //LevelService.NextLevel();
        }
    }
}
