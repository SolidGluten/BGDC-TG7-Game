using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Level : MenuItem
{
    public bool isLocked;
    public int levelIndex;
    public TextMeshProUGUI text;
    public Color UnlockedColor;
    public Color LockedColor;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public override void OnSelect()
    {
        if (isLocked) return;
        StartCoroutine(LevelManager.instance.ChangeLevel(levelIndex));
    }

    public void Lock(bool isLock) //true = locked; false = unlocked
    {
        if (levelIndex == 6) gameObject.SetActive(!isLock? true : false); //only apply for Overtime
        isLocked = isLock;
        text.color = isLock ? LockedColor : UnlockedColor;
        isHoverable = !isLock;  
    }
}
