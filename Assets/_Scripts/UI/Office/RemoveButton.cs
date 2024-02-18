using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RemoveButton : MonoBehaviour
{
    private RoomManager roomManager;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        SceneManager.sceneLoaded += GetReference;
    }

    private void GetReference(Scene scene, LoadSceneMode mode)
    {
        if (roomManager == null)
        {
            roomManager = FindAnyObjectByType<RoomManager>();
            button.onClick.AddListener(() => roomManager.RemoveFood());
        }
    }
}
