using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<LevelUI> levelObj = new List<LevelUI>();

    private void Update()
    {
        List<Level> tempList = GameManager.instance.LevelList;
        for (int i = 0; i <  tempList.Count; i++)
        {
            if (tempList[i].isAccesible) levelObj[i].Unlock();
            else levelObj[i].Lock();
        }
    }
}
