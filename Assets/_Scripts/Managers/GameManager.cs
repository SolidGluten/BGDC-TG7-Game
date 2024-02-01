using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum DeathCondition {WrongOrder, Frying, Fishing, Garden, HotPot};
public enum GameState { MainMenu, Playing, Dead, Paused }

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameState currentState;

    private void Awake()
    {
        if (instance != null & instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
            instance = this;

        DontDestroyOnLoad(gameObject);
        if (SceneManager.GetActiveScene().buildIndex != 0)
            SceneManager.LoadScene(0); //starts from the main menu
        currentState  = GameState.MainMenu;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.Paused)
                Resume();
            else if(currentState == GameState.Playing)
                Pause();
        }
    }

    public void Pause()
    {
        SoundManager.instance.PauseAllSounds(true);
        PauseMenu.instance.SetPauseActive(true);
        currentState = GameState.Paused;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        SoundManager.instance.PauseAllSounds(false);
        PauseMenu.instance.SetPauseActive(false);
        currentState = GameState.Playing;
        Time.timeScale = 1;
    }

    public void Death(DeathCondition cond)
    {
        //currentState = GameState.Dead;
        switch (cond)
        {
            case DeathCondition.Frying:
                {
                    break;
                }
        }
    }

    [ContextMenu("Remove All Player Prefs")]
    public void RemoveAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}



