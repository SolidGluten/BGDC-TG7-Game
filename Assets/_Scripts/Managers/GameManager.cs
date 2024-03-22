    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public enum DeathCondition {WrongOrder, PatienceGone, Frying, Fishing, Garden, HotPot};
public enum GameState { MainMenu, Playing, Dead, Paused }

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameState currentState;
    public TextMeshProUGUI deathReason;
    public float backToMenuDelay;

    public static event Action OnBackToMenu;

    private void Awake()
    {
        if (instance != null && instance != this)
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
        if (Input.GetKeyDown(KeyCode.Escape) && currentState != GameState.MainMenu)
        {
            if (currentState == GameState.Paused)
                Resume();
            else if(currentState == GameState.Playing)
                Pause();
        }
    }

    public IEnumerator BackToMenu()
    {
        //Resume();
        Time.timeScale = 1f;
        OnBackToMenu?.Invoke();
        yield return new WaitForSeconds(backToMenuDelay);
        SceneManager.LoadScene(0);
        DeathScreen.instance.SetDeathTrue(false);
        currentState = GameState.MainMenu;
    }

    public void Pause()
    {
        SoundManager.instance.PauseAllSounds(true);
        PauseMenu.instance.SetPauseActive(true);
        currentState = GameState.Paused;
        Time.timeScale = 0f;
    }
    public void RecipeBooking()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0f;
        }
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
        currentState = GameState.Dead;
        switch (cond)
        {
            case DeathCondition.WrongOrder:
                {
                    Debug.Log("Player died while serving food.");
                    deathReason.text = "You served the wrong food, now you will be served as food";
                    break;
                }
            case DeathCondition.PatienceGone:
                {
                    Debug.Log("Player died due to the customer waiting too long.");
                    deathReason.text = "You took too long to serve food, but they have you as an emergency food";
                    break;
                }
            case DeathCondition.Frying:
                {
                    Debug.Log("Player died due to frying something for too long.");
                    deathReason.text = "You were fried to a perfect golden brown color";
                    break;
                }
            case DeathCondition.Fishing:
                {
                    Debug.Log("Player died due to taking too long when fishing.");
                    deathReason.text = "You caught something beyond your comprehension and went mad because of it";
                    break;
                }
            case DeathCondition.Garden:
                {
                    Debug.Log("Player died due to growing something for too long.");
                    deathReason.text = "You planted something that grew into some eerie unnatural shapes and you lost your consciousness when you see it";
                    break;
                }
            case DeathCondition.HotPot:
                {
                    Debug.Log("Player died due to boiling something for too long.");
                    deathReason.text = "You boiled the liquid for too long that it evaporated, mixing with the air turning it to a noxious gas";
                    break;
                }
        }
        DeathScreen.instance.SetDeathTrue(true);
    }
    [ContextMenu("Unlock All Levels")]
    public void UnlockAllLevel()
    {
        PlayerPrefs.SetInt("UnlockedLevel", 6);
    }

    [ContextMenu("Remove All Player Prefs")]
    public void RemoveAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}



