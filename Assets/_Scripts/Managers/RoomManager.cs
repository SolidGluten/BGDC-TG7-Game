using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Recorder.OutputPath;

//enum has an order
//Default = 0
//Cashier = 1
//FryingPan = 2
//...

public enum RoomCode { Cashier = 1, Storage, Fishing, Garden, FryingPan, CuttingRoom, DeepFryer, Fermentation, Drinks }

public class RoomManager : MonoBehaviour
{
    public static RoomCode activeRoomCode = RoomCode.Cashier;
    public Room currentActiveRoom;
    public List<Room> roomList = new List<Room>();

    public Vector3 activeRoomPos;
    public float roomDistance = 5;

    private void Start()
    {
        for(int i = 0; i < roomList.Count; i++)
        {
            switch (roomList[i].roomCode)
            {
                case RoomCode.Cashier:
                    {
                        roomList[i].isAccesible = true;
                        break;
                    }
                case RoomCode.Storage:
                    {
                        if((LevelManager.currentLevel.accesibleRooms & AccesibleRoom.Storage) == AccesibleRoom.Storage)
                            roomList[i].isAccesible = true;
                        else
                            roomList[i].isAccesible = false;
                        break;
                    }
                case RoomCode.Fishing:
                    {
                        if ((LevelManager.currentLevel.accesibleRooms & AccesibleRoom.Fishing) == AccesibleRoom.Fishing)
                            roomList[i].isAccesible = true;
                        else
                            roomList[i].isAccesible = false;
                        break;
                    }
                case RoomCode.Garden:
                    {
                        if ((LevelManager.currentLevel.accesibleRooms & AccesibleRoom.Garden) == AccesibleRoom.Garden)
                            roomList[i].isAccesible = true;
                        else
                            roomList[i].isAccesible = false;
                        break;
                    }
                case RoomCode.FryingPan:
                    {
                        if ((LevelManager.currentLevel.accesibleRooms & AccesibleRoom.FryingPan) == AccesibleRoom.FryingPan)
                            roomList[i].isAccesible = true;
                        else
                            roomList[i].isAccesible = false;
                        break;
                    }
                case RoomCode.CuttingRoom:
                    {
                        if ((LevelManager.currentLevel.accesibleRooms & AccesibleRoom.CuttingRoom) == AccesibleRoom.CuttingRoom)
                            roomList[i].isAccesible = true;
                        else
                            roomList[i].isAccesible = false;
                        break;
                    }
                case RoomCode.DeepFryer:
                    {
                        if ((LevelManager.currentLevel.accesibleRooms & AccesibleRoom.DeepFryer) == AccesibleRoom.DeepFryer)
                            roomList[i].isAccesible = true;
                        else
                            roomList[i].isAccesible = false;
                        break;
                    }
                case RoomCode.Fermentation:
                    {
                        if ((LevelManager.currentLevel.accesibleRooms & AccesibleRoom.Fermentation) == AccesibleRoom.Fermentation)
                            roomList[i].isAccesible = true;
                        else
                            roomList[i].isAccesible = false;
                        break;
                    }
                case RoomCode.Drinks:
                    {
                        if ((LevelManager.currentLevel.accesibleRooms & AccesibleRoom.Drinks) == AccesibleRoom.Drinks)
                            roomList[i].isAccesible = true;
                        else
                            roomList[i].isAccesible = false;
                        break;
                    }
                default: { break; }
            }
        }
        SetRoomActive(activeRoomCode);
    }

    private void Update()
    {
        if(GameManager.currentState != GameState.Playing)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetRoomActive((RoomCode)1); 
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetRoomActive((RoomCode)2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetRoomActive((RoomCode)3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetRoomActive((RoomCode)4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetRoomActive((RoomCode)5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SetRoomActive((RoomCode)6);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SetRoomActive((RoomCode)7);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SetRoomActive((RoomCode)8);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SetRoomActive((RoomCode)9);
        }
    }

    public void SetRoomActive(RoomCode code)
    {
        List<Room> newList = roomList;

        int nextRoomIndex = newList.FindIndex(room => room.roomCode == code);
        Room nextRoom = newList[nextRoomIndex];

        if(nextRoom.isAccesible == false)
        {
            Debug.LogWarning("Room is not Accessible!");
            return;
        }

        if (newList[0].roomCode != code)
            SwapRoom(newList, nextRoomIndex, 0); //swaps the next room being activated with the 2nd roomn in the list

        currentActiveRoom = nextRoom;
        activeRoomCode = nextRoom.roomCode;

        int multiplier = 0;
        foreach (Room room in newList)
        {
            room.SetRoomPos(activeRoomPos + roomDistance * multiplier * Vector3.right);
            room.gameObject.SetActive(true);

            if(room.roomElevator.foodObj != null)
            {
                room.roomElevator.foodObj?.GetComponent<Dragable>().ResetPosition();    
            }

            multiplier++;
        }
    }

    public void SwapRoom(List<Room> list, int index1, int index2)
    {
        Room temp = list[index1];
        list[index1] = list[index2];
        list[index2] = temp;
    }

    public void SendFood(int code)
    {
        if(currentActiveRoom.roomElevator == null)
        {
            return;
        }

        if(!currentActiveRoom.roomElevator.foodObj)
        {
            Debug.LogWarning("Fud not found in the elevator");
            return;
        }
        
        var roomDestination = roomList.Find(i => i.roomCode == (RoomCode)code);
        if (roomDestination == null)
        {
            Debug.LogWarning("Room not found!");
            return;
        }

        if(roomDestination.isAccesible == false)
        {
            Debug.LogWarning("Room is not accesible!");
            return;
        }

        if (roomDestination.roomElevator.foodObj != null)
        {
            Debug.LogWarning("Elevator is already loaded!");
            return;
        }
        
        roomDestination.roomElevator.foodObj = currentActiveRoom.roomElevator.foodObj;

        GameObject FoodObj = currentActiveRoom.roomElevator.foodObj;
        FoodObj.transform.parent = roomDestination.gameObject.transform;
            
        FoodObj.GetComponent<Dragable>().SetLastPosition(roomDestination.roomElevator.gameObject.transform);
        FoodObj.GetComponent<Dragable>().ResetPosition();

        currentActiveRoom.roomElevator.foodObj = null;
        Debug.Log("Sent Succesfully! ");
    }

    public void RemoveFood()
    {
        if (currentActiveRoom.roomElevator.foodObj != null)
            Destroy(currentActiveRoom.roomElevator.foodObj);
    }
}

