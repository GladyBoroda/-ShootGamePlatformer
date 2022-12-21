using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChargeJumpIcon : MonoBehaviour
{
    public Image Background;
    public Image Foreground;
    public TextMeshProUGUI Text;

    public void StartCharge()
    {
        Background.color = new Color(1, 0.6338634f, 0.03301889f, 0.2f) ;
        Foreground.enabled = true;
        Text.enabled = true;
    }

    public void StopCharge()
    {
        Background.color = new Color(1, 0.6338634f, 0.03301889f, 1);
        Foreground.enabled = false;
        Text.enabled = false;
    }

    public void SetChargeValue(float currentCharge, float maxChargeCharge)
    {
        Foreground.fillAmount = currentCharge / maxChargeCharge;
        Text.text = Mathf.Ceil(maxChargeCharge - currentCharge).ToString();
    }
}
