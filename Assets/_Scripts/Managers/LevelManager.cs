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

    public IEnumerator RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.instance.Resume();
        yield return null;
    }

    public void LoadLevel(int index)
    {
        //Load level
        currentLevelIndex = index;
        currentLevel = LevelList[currentLevelIndex];
        SceneManager.LoadScene(LevelList[index].sceneBuildIndex);
        LevelList[index].isAccesible = true;
        if (currentLevelIndex > CurrentLevelIndexUnlocked)
        {
            CurrentLevelIndexUnlocked = currentLevelIndex;
            PlayerPrefs.SetInt("UnlockedLevel", CurrentLevelIndexUnlocked);
        }

        //Reset game settings
        GeneralSpeed = LevelList[index].generalSpeed;
        MaxOrder = LevelList[index].totalOrders;
        MaxPatience = (15 / GeneralSpeed) + 15;
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
    public AccesibleRoom accesibleRooms;
}
