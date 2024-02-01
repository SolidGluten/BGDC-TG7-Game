using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    //The roomcode of this particular room
    public RoomCode roomCode;
    public Elevator roomElevator;
    public bool isAccesible;

    //A function just to activate this gameObject
    public void SetRoomPos(Vector3 pos)
    {
        transform.position = pos;
    }
}
