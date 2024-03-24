    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public enum DeathCondition {WrongOrder, PatienceGone, Frying, Fishing, Garden, HotPot};
public enum GameState { MainMenu, Playing, Dead, Paused, PopupOpen }

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameState currentState;
    public TextMeshProUGUI deathReason;
    public float backToMenuDelay;
    public bool isBooking = false;
    private int SFXindex = 15;

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
        if (Input.GetKeyDown(KeyCode.Escape) && currentState != GameState.MainMenu && currentState != GameState.PopupOpen)
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
        Debug.Log("BackToMenu");
        yield return new WaitForSeconds(backToMenuDelay);
        SceneManager.LoadScene(0);
        WinCanvasManager.Instance.SetWinScreen(false);
        SoundManager.instance.StopAllSounds();
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
        isBooking = !isBooking;
        if (isBooking) Pause();
        else Resume();
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
        Time.timeScale = 0;
        currentState = GameState.Dead;
        switch (cond)
        {
            case DeathCondition.WrongOrder:
                {
                    Debug.Log("Player died while serving food.");
                    deathReason.text = "Reason : You served the wrong food.";
                    break;
                }
            case DeathCondition.PatienceGone:
                {
                    Debug.Log("Player died due to the customer waiting too long.");
                    deathReason.text = "Reason : You ran out of time.";
                    break;
                }
            case DeathCondition.Frying:
                {
                    Debug.Log("Player died due to frying something for too long.");
                    deathReason.text = "Reason : You left the pan cooking for too long.";
                    break;
                }
            case DeathCondition.Fishing:
                {
                    Debug.Log("Player died due to taking too long when fishing.");
                    deathReason.text = "Reason : You left the fish on the line for too long.";
                    break;
                }
            case DeathCondition.Garden:
                {
                    Debug.Log("Player died due to growing something for too long.");
                    deathReason.text = "Reason : You typed in the wrong code.";
                    break;
                }
            case DeathCondition.HotPot:
                {
                    Debug.Log("Player died due to boiling something for too long.");
                    deathReason.text = "Reason : You left the pot heat up for too long.";
                    break;
                }
        }
        SoundManager.instance.PlaySoundEffect(SFXindex);
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



