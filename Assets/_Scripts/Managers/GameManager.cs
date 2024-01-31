using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum DeathCondition { Frying };

public enum GameState { MainMenu, Playing, Dead, Paused }

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float GeneralSpeed = 1;
    public int MaxOrder = 1;
    public static int CurrentOrderServed = 0;
    public float MaxPatience = 1;
    public GameState currentState;
    public int currentLevelIndex;
    public GameObject pauseMenu;
    [SerializeField] private float delayBeforeNextLevel;
    public List<Level> LevelList = new List<Level>();
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
        currentState = GameState.MainMenu;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //bool isPaused = !pauseMenu.activeSelf;
            //pauseMenu.SetActive(isPaused);

            if (currentState == GameState.Paused)
            {
                Resume();
                currentState = GameState.Playing;
            }
            else
            {
                Pause();
                currentState = GameState.Paused;
            }
        }
    }

    public IEnumerator ChangeLevel(int index)
    {
        currentState = GameState.Playing;
        yield return new WaitForSeconds(delayBeforeNextLevel);
        if (index == LevelList.Count)
        {
            //End message
        }
        else
        {
            LoadLevel(index);
        }
    }

    public void LoadLevel(int index)
    {
        currentLevelIndex = index;
        SceneManager.LoadScene(LevelList[index].sceneBuildIndex);
        LevelList[index].isAccesible = true;
        GeneralSpeed = LevelList[index].generalSpeed;
        MaxOrder = LevelList[index].totalOrders;
        MaxPatience = (15 / GeneralSpeed) + 15;
        CurrentOrderServed = 0;
        Resume();
    }

    public IEnumerator RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        yield return null;
    }

    public void Pause()
    {
        if(currentState == GameState.Playing)
        {
            SoundManager.instance.PauseAllSounds(true);
            PauseMenu.instance.SetPauseActive(true);
            currentState = GameState.Paused;
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
        //currentState = GameState.Dead;
        switch (cond)
        {
            case DeathCondition.Frying:
                {
                    break;
                }
        }
    }

    public void UpdateOrderCount()
    {
        CurrentOrderServed++;
        if (CurrentOrderServed >= MaxOrder)
        {
            StartCoroutine(ChangeLevel(currentLevelIndex + 1));
        }
    }
}

[Serializable]
public class Level
{
    [SerializeField] private string LevelName;
    public int sceneBuildIndex;
    [Range(1, 5)] public float generalSpeed = 1;
    [SerializeField] public int totalOrders;
    [SerializeField] public bool isAccesible;
}

