using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    public Image DamageImage;
    
    public void StartEffect()
    {
        StartCoroutine(ShowEffect());
    }

    public IEnumerator ShowEffect()
    {
        for (float t = 1; t > 0; t-=Time.deltaTime)
        {
            DamageImage.enabled = true;
            DamageImage.color = new Color(1, 0, 0, t);
            yield return null;
            DamageImage.enabled = false;
        }
    }
}
