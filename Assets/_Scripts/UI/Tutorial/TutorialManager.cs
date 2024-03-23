using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI titleUI;
    public TextMeshProUGUI contentUI;

    public List<TutorialPageDetails> pages = new List<TutorialPageDetails>();
    public int currentPageIndex = 0;
    private int currentSavedPage = 0;

    public static TutorialManager instance;

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
    }

    private void OnEnable()
    {
        GameManager.currentState = GameState.PopupOpen;
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        GameManager.currentState = GameState.Playing;
        Time.timeScale = 1f;
        Time.timeScale = 1f;
    }

    private void Start()
    {
        currentSavedPage = PlayerPrefs.GetInt("tutorialPage", 7);
        UpdatePage(currentPageIndex);
        gameObject.SetActive(false);
        
        for(int i = 0; i < currentSavedPage; i++)
        {
            pages[i].Unlock();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            this.gameObject.SetActive(false);
        }
    }

    public void NextPage()
    {
        if (currentPageIndex < pages.Count - 1 && pages[currentPageIndex+1].isUnlocked) { 
            currentPageIndex++;
            UpdatePage(currentPageIndex);
        }
    }

    public void PreviousPage()
    {
        if (currentPageIndex > 0 && pages[currentPageIndex-1].isUnlocked) { 
            currentPageIndex--;
            UpdatePage(currentPageIndex);
        }
    }

    public void UpdatePage(int pageIdx){
        titleUI.text = pages[pageIdx].Title;
        contentUI.text = pages[pageIdx].Description;
    }

    public void UnlockPage(string key) {
        for(int i = 0; i < pages.Count; i++)
        {
            if (pages[i].Key == key) {
                if (i + 1 > currentSavedPage)
                    PlayerPrefs.SetInt("tutorialPage", i + 1);
                pages[i].Unlock();
            }
        }
    }
}

[Serializable]
public class TutorialPageDetails {
    public string Title;
    [TextAreaAttribute(5, 15)]
    public string Description;
    public bool isUnlocked = false;
    public string Key = "default";
    public void Unlock() {
        TutorialPanel.instance.ShowAlert();
        isUnlocked = true; 
    }
}
