using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelService : MonoBehaviour
{
    public List<GameObject> Level = new List<GameObject>();
    public GameObject CurrentLevel;
    public int CurrentLevelIndex;
    public GameObject player;
    public UiService UiService;
    public Canvas FinishMenuCanvas;

    private Vector3 initPosition;

    

    private void Awake()
    {
        initPosition = player.transform.position;
        CurrentLevelIndex = 0;
        CurrentLevel = Instantiate(Level[0]);
    }
    public void RestartLevel()
    {
        UiService.CloseMenuWindow();

        LoadLevel(CurrentLevelIndex);
    }
    public void LoadLevel(int level)
    {
        CurrentLevelIndex = level;
        player.transform.position = initPosition;
        Destroy(CurrentLevel);
        CurrentLevel = Instantiate(Level[level]);
    }

    public void NextLevel()
    {
        FinishMenuCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        CurrentLevelIndex++;
        CurrentLevelIndex %= Level.Count;
        LoadLevel(CurrentLevelIndex);

    }
}
