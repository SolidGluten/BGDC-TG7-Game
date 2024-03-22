using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_StartDay : MenuItem
{
    public TextMeshProUGUI currentDayText;
    private int currDayIndex;

    private void Awake()
    {
        currDayIndex = PlayerPrefs.GetInt("UnlockedLevel", 0);
        SceneManager.sceneLoaded += OnSceneLoaded;    
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public override void OnSelect() {
        StartCoroutine(LevelManager.instance.ChangeLevel(currDayIndex));
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int currDay = currDayIndex + 1;
        if (currDay != 7) 
            currentDayText.text = "Start Day " + currDay;
        else
            currentDayText.text = "Start Overtime";
    }
}
