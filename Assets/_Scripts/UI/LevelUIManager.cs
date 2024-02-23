using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUIManager : MonoBehaviour
{
    public List<UI_Level> levelObj = new List<UI_Level>();


    private void Update()
    {
        List<Level> tempList = LevelManager.instance.LevelList;
        for (int i = 0; i < tempList.Count; i++)
        {
            if (tempList[i].isAccesible) levelObj[i].Lock(false);
            else levelObj[i].Lock(true);
        }
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

    }
}
