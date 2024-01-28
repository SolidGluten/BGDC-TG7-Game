using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingRoom : Processor
{
    [HideInInspector] public Room room;
    private void Start()
    {
        room = GetComponent<Room>();
    }
}
