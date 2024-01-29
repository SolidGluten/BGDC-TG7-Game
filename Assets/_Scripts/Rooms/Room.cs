using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    //Each room will be able to hold dem food
    public GameObject currentFoodHolder;
    //The roomcode of this particular room
    public RoomCode roomCode;
    public Elevator roomElevator;

    //A function just to activate this gameObject
    public void SetRoomPos(Vector3 pos)
    {
        transform.position = pos;
    }
}
