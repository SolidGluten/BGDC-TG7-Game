using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Level : MenuItem
{
    public bool isLocked;
    public int levelIndex;
    public TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>(); 
    }

    public override void OnSelect()
    {
        if (isLocked) return;
        StartCoroutine(GameManager.instance.ChangeLevel(levelIndex));
    }

    public void Lock(bool isLock) //true = locked; false = unlocked
    {
        isLocked = isLock;
        text.color = isLock ? Color.gray : Color.white;
    }
}
