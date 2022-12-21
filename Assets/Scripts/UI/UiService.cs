using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiService : MonoBehaviour
{
    public Canvas FinishMenuCanvas;
    public Canvas DeathMenuCanvas;
    public GameObject MenuButton;
    public GameObject MenuWindow;

    public MonoBehaviour[] ComponentsToDisabled;

    public void Finish()
    {
        FinishMenuCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Death()
    {
        DeathMenuCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void OpenMenuWindow()
    {
        MenuWindow.SetActive(true);
        MenuButton.SetActive(false);

        for (int i = 0; i < ComponentsToDisabled.Length; i++)
        {
            ComponentsToDisabled[i].enabled = false;
        }
        Time.timeScale = 0;
    }

    public void CloseMenuWindow()
    {
        Time.timeScale = 1;
        for (int i = 0; i < ComponentsToDisabled.Length; i++)
        {
            ComponentsToDisabled[i].enabled = true;
        }

        MenuWindow.SetActive(false);
        MenuButton.SetActive(true);
    }

}
