using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DeathCondition{Frying};

public class GameManager : MonoBehaviour
{
    public static float GeneralSpeed = 4;
    public static int MaxOrder = 4;
    public static float MaxPatience = 15 / GeneralSpeed + 15;

    public static void Death(DeathCondition cond)
    {
        switch(cond)
        {
            case DeathCondition.Frying:
            {
                break;
            }
        }
    }
}
