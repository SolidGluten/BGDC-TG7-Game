using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float GeneralSpeed = 1;
    public float MaxPatience = 1;
    public int MaxOrder = 1;
    public static int CurrentOrderServed = 0;

    public static Level currentLevel;
    public int currentLevelIndex;
    public int CurrentLevelIndexUnlocked = 0;

    [SerializeField] private float delayBeforeNextLevel;
    public List<Level> LevelList = new List<Level>();

    public static event Action OnLevelChanging;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }

        //get current day from previous play
        CurrentLevelIndexUnlocked = PlayerPrefs.GetInt("UnlockedLevel", 0);

        //unlock every level from previous play
        for (int i = 0; i <= CurrentLevelIndexUnlocked; i++)
        {
            LevelList[i].isAccesible = true;
        }
    }

    public void ShowWinScreen()
    {
        WinCanvasManager.Instance.SetWinMessage(currentLevel.levelName + " has ended.");

        if (currentLevelIndex != LevelList.Count - 1)
            WinCanvasManager.Instance.SetWinScreen(true);
        else
            WinCanvasManager.Instance.ShowLastWinScreen();

        LevelList[currentLevelIndex + 1].isAccesible = true;
        CurrentLevelIndexUnlocked = currentLevelIndex + 1;
        PlayerPrefs.SetInt("UnlockedLevel", CurrentLevelIndexUnlocked);
    }

    public IEnumerator ChangeLevel(int index)
    {
        if (OnLevelChanging != null) OnLevelChanging();
        GameManager.currentState = GameState.Loading;

        yield return new WaitForSeconds(delayBeforeNextLevel);

        currentLevelIndex = index;
        LoadLevel(index);
        WinCanvasManager.Instance.SetWinScreen(false);
    }

    public void RetryLevel()
    {
        SoundManager.instance.StopAllSounds();
        StartCoroutine(ChangeLevel(currentLevelIndex));
        Time.timeScale = 1.0f;
        SoundManager.instance.PlayBackgroundMusic();
    }

    public void LoadLevel(int index)
    {
        //Load level
        currentLevel = LevelList[index];
       
        //Unlock Tutorial Page
        TutorialManager.instance.UnlockPage(LevelList[index]?.tutorialKey);

        SceneManager.LoadScene(LevelList[index].sceneBuildIndex);

        //Save current level
        
        //Reset game settings
        GeneralSpeed = LevelList[index].generalSpeed;
        MaxOrder = LevelList[index].totalOrders;
        MaxPatience = (15 / GeneralSpeed) + 30;
        CurrentOrderServed = 0;

        GameManager.instance.Resume();
    }

    public void UpdateOrderCount()
    {
        CurrentOrderServed++;
        if (CurrentOrderServed >= MaxOrder)
        {
            ShowWinScreen();
        }
    }
}

[Flags] public enum AccesibleRoom
{
    Storage = 1, 
    Fishing = 2, 
    Garden = 4, 
    FryingPan = 8, 
    CuttingRoom = 16, 
    DeepFryer = 32, 
    Fermentation = 64, 
    Drinks = 128
}

[Serializable]
public class Level
{
    public string levelName;
    public int sceneBuildIndex;
    [Range(1, 5)] public float generalSpeed = 1;
    public int totalOrders;
    public bool isAccesible;
    public string tutorialKey = "default";
    public AccesibleRoom accesibleRooms;
}
