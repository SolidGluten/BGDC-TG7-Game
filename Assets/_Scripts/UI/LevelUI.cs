
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelUI : MonoBehaviour
{
    public Image lockImg;
    public bool isLocked = true;
    public int levelToLoad;

    public void Unlock()
    {
        isLocked = false;
        lockImg.gameObject.SetActive(false);
    }

    public void Lock()
    {
        isLocked = true;
        lockImg.gameObject.SetActive(true);
    }

    public void GoToLevel()
    {
        if (!isLocked)
        {
            StartCoroutine(GameManager.instance.ChangeLevel(levelToLoad));
        }
    }
}
