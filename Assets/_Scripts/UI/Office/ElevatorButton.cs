using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ElevatorButton : MonoBehaviour
{
    public RoomCode roomTo;
    private RoomManager roomManager;
    private Button button;
    private int SFXindex = 5;

    private void Start()
    {
        button = GetComponent<Button>();
        SceneManager.sceneLoaded += GetReference;
        
        button.onClick.AddListener(() => SoundManager.instance.PlaySoundEffect(SFXindex));
    }

    private void GetReference(Scene scene, LoadSceneMode mode)
    {
        if(roomManager == null)
            button.onClick.RemoveAllListeners();
            roomManager = FindAnyObjectByType<RoomManager>();

        if(roomManager != null) 
            button.onClick.AddListener(() => roomManager.SendFood((int)roomTo));
     
    }
}
