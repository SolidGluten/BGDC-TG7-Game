using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingRoom : Processor
{
    [HideInInspector] public Room room;
    private void Awake()
    {
        room = GetComponent<Room>();
    }
}
