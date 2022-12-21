using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject MenuButton;
    public GameObject MenuWindow;
    public GameObject FinishWindow;

    //public MonoBehaviour[] ComponentsToDisabled;

    public void OpenMenuWindow()
    {
        MenuWindow.SetActive(true);
        MenuButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void CloseMenuWindow()
    {
        Time.timeScale = 1;
        MenuWindow.SetActive(false);
        MenuButton.SetActive(true);
    }

    
}
