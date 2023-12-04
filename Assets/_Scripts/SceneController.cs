using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Rooms{Cashier = 2, Frying, Garden}

public class SceneController : MonoBehaviour
{
    public int currentRoomIndex;

    public void Start()
    {
        SceneManager.LoadScene((int)Rooms.Cashier, LoadSceneMode.Additive);
        currentRoomIndex = (int)Rooms.Cashier;
    }

    public void ChangeSceneAdditive(int roomIndx)
    {
        SceneManager.UnloadSceneAsync(currentRoomIndex);
        SceneManager.LoadScene(roomIndx, LoadSceneMode.Additive);
        currentRoomIndex = roomIndx;
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(currentRoomIndex));
    }
}
