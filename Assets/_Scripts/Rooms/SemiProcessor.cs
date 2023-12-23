using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiProcessor : MonoBehaviour
{
    public List<SemiProcessedScriptable> semiProcessedList = new List<SemiProcessedScriptable>();
    public GameObject SemiProcessedObj;

    public SemiProcessedScriptable FindProcessedOutput(IngredientsScriptable currIngredient)
    {
        foreach (SemiProcessedScriptable obj in semiProcessedList)
        {
            if (obj.ingredient == currIngredient)
            {
                return obj;
            }
        }

        Debug.Log("No processed found!");
        return null;
    }

    //Spawn Processed Food
    public GameObject SpawnProcessFood(Vector2 spawnPos, SemiProcessedScriptable semiProcessed)
    {
        GameObject semiProcessedObj = Instantiate(SemiProcessedObj, spawnPos, Quaternion.identity);
        semiProcessedObj.GetComponent<SemiProcessed>().semiProcessedScriptable = semiProcessed;
        semiProcessedObj.transform.parent = transform;

        return semiProcessedObj;
    }
}
