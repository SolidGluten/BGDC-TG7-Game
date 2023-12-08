using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Rooms{Cashier = 2, Frying, Garden}

public class SceneController : MonoBehaviour
{
    public int currentRoomIndex;

    public void Start()
    {
        //Load default scene
        SceneManager.LoadScene((int)Rooms.Cashier, LoadSceneMode.Additive);
        currentRoomIndex = (int)Rooms.Cashier;
    }

    public IEnumerator ChangeScene(int roomIndx)
    {
        //Dont change scene if we're changing into the same scene
        if(roomIndx == currentRoomIndex)
        {
            yield break;
        }

        SceneManager.UnloadSceneAsync(currentRoomIndex);
        AsyncOperation sceneLoaded = SceneManager.LoadSceneAsync(roomIndx, LoadSceneMode.Additive);
        //Wait for the scene to finish loading
        while (!sceneLoaded.isDone)
        {
            //Debug.Log(sceneLoaded.progress);
            yield return null;
        }
        currentRoomIndex = roomIndx;
        //Change active scene as the current room index
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(currentRoomIndex));
    }
}
