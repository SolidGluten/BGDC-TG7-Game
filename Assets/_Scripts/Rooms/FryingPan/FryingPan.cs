using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

public class FryingPan : Processor
{
    public Room room;

    private void Awake()
    {
        room = GetComponentInParent<Room>();
    }

}
