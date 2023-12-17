using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DeathCondition{Frying};

public class GameManager : MonoBehaviour
{
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
