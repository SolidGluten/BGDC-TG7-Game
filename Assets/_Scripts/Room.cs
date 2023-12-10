using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject currentFoodHolder;
    public RoomCode roomCode;

    public void SetRoomActive(bool active)
    {
        this.gameObject.SetActive(active);
    }
}
