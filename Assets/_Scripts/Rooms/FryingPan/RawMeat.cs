using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawMeat : MonoBehaviour
{
    public static int RawMeatAmount;

    private void Awake()
    {
        RawMeatAmount++;
    }

    private void OnDestroy()
    {
        RawMeatAmount--;
    }
}
