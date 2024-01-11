using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingRoom : SemiProcessor
{
    public Room room;
    private void Start()
    {
        room = GetComponent<Room>();
    }
}
