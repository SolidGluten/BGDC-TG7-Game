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
    [SerializeField] bool isSending = false;
    public Room roomDestination;

    private void Start()
    {
        currentActiveRoom.SetRoomActive(true);  
    }

    public void ChangeRoom(int nextRoomCode){
        if (isSending) return;
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

    public void SendMode()
    {
        isSending = !isSending;
        roomDestination = null;
    }

    public void SetRoomDestination(int code)
    {
        if (!isSending) return;

        roomDestination = roomList.Find(i => i.roomCode == (RoomCode)code);
        if(roomDestination == null)
        {
            Debug.Log("Room not found!");
        }
    }

    public void SendFood()
    {
        if (!isSending) return;

        if (roomDestination == null)
        {
            Debug.Log("Room not found!");
            return;
        }

        Debug.Log("Sent Succesfully!");
        roomDestination.roomElevator.foodObj = currentActiveRoom.roomElevator.foodObj;

        GameObject Food = currentActiveRoom.roomElevator.foodObj;
        Food.transform.parent = roomDestination.gameObject.transform;

        currentActiveRoom.roomElevator.foodObj = null;
        isSending = false;
    }
}

