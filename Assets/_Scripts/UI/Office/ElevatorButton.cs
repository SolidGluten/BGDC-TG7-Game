using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorButton : MonoBehaviour
{
    public RoomCode roomTo;
    private RoomManager roomManager;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    private void Update()
    {
        if (roomManager == null && GameManager.currentState == GameState.Playing)
        {
            roomManager = FindAnyObjectByType<RoomManager>();
            button.onClick.AddListener(() => roomManager.SendFood((int)roomTo));
        }   
    }
}
