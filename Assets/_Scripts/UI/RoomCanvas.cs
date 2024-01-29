using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCanvas : MonoBehaviour
{
    private Room room;

    private void Start()
    {
        room = GetComponentInParent<Room>();
    }

    private void Update()
    {
        if(RoomManager.activeRoomCode == room.roomCode)
            foreach (var UIelement in GetComponentsInChildren<RectTransform>())
                UIelement.localScale = Vector3.one;
        else
            foreach (var UIelement in GetComponentsInChildren<RectTransform>())
                UIelement.localScale = Vector3.zero;
    }
}
