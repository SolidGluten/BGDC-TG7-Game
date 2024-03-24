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

    public IEnumerator ChangeLevel(int index)
    {
        GameManager.currentState = GameState.Playing;

        if (currentLevelIndex == LevelList.Count - 2) { //On day 6
            WinCanvasManager.Instance.SetWinScreen(true);
            WinCanvasManager.Instance.SetWinMessage("Day 6 has ended");
            yield break;
        }

        if (index >= LevelList.Count) { //After 
            WinCanvasManager.Instance.SetWinScreen(true);
            WinCanvasManager.Instance.SetWinMessage("Overtime has ended.");
            yield break;
        }

        if (OnLevelChanging != null) OnLevelChanging();

        yield return new WaitForSeconds(delayBeforeNextLevel);


        currentLevelIndex = index;
        if (currentLevelIndex > CurrentLevelIndexUnlocked)
        {
            LevelList[index].isAccesible = true;
            CurrentLevelIndexUnlocked = currentLevelIndex;
            PlayerPrefs.SetInt("UnlockedLevel", CurrentLevelIndexUnlocked);
        }

        LoadLevel(index);
    }

    public void RetryLevel()
    {
        SoundManager.instance.StopAllSounds();
        StartCoroutine(ChangeLevel(currentLevelIndex));
        GameManager.instance.Resume();
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
            StartCoroutine(ChangeLevel(currentLevelIndex + 1));
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
    [SerializeField] private string levelName;
    public int sceneBuildIndex;
    [Range(1, 5)] public float generalSpeed = 1;
    public int totalOrders;
    public bool isAccesible;
    public string tutorialKey = "default";
    public AccesibleRoom accesibleRooms;
}
