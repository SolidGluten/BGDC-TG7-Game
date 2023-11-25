using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Rooms{Cashier, Frying, Garden}

public class SceneController : MonoBehaviour
{
    public static void ChangeSceneAdditive(int roomIndx)
    {
        SceneManager.LoadScene(roomIndx, LoadSceneMode.Additive);
    }
}
