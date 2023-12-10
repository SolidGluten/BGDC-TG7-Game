using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enum has an order
//Default = 0
//Cashier = 1
//FryingPan = 2
//...

[Serializable] public enum RoomCode{Default, Cashier, FryingPan, DeepFryer, CuttingBoard, Oven, Soup, Garden, FishingSpot, Freezer}

public class RoomManager : MonoBehaviour
{
    public Room currentActiveRoom;
    public List<Room> roomList = new List<Room>();

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void ChangeRoom(int nextRoomCode){ 
        //iterate every rooms in the list
        foreach (Room room in roomList)
        {
            //if the the room headed to is found then change to it
            if(room.roomCode == (RoomCode)nextRoomCode)
            {
                //disable the current room
                currentActiveRoom.SetRoomActive(false);
                //set the current room as the next room
                currentActiveRoom = room;
                //set the next room as active
                currentActiveRoom.SetRoomActive(true);
                return;
            }
        }

        Debug.Log("Room not found!");
        return;
    }
}

