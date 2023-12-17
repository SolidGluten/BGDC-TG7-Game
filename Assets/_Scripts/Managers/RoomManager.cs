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
    public Room roomDestination;

    private void Start()
    {
        currentActiveRoom.SetRoomActive(true);  
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeRoom(1);
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeRoom(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeRoom(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeRoom(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ChangeRoom(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ChangeRoom(6);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            ChangeRoom(7);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            ChangeRoom(8);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            ChangeRoom(9);
        }
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


    public void SendFood(int code)
    {
        if(currentActiveRoom.roomElevator.foodObj == null)
        {
            Debug.Log("Fud not found in the elevator");
            return;
        }

        roomDestination = roomList.Find(i => i.roomCode == (RoomCode)code);
        if (roomDestination == null)
        {
            Debug.Log("Room not found!");
            return;
        }
        
        roomDestination.roomElevator.foodObj = currentActiveRoom.roomElevator.foodObj;

        GameObject Food = currentActiveRoom.roomElevator.foodObj;
        Food.transform.parent = roomDestination.gameObject.transform;

        currentActiveRoom.roomElevator.foodObj = null;
        Debug.Log("Sent Succesfully! ");
    }
}

