using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SemiProcessor : MonoBehaviour
{
    //public List<SemiProcessedScriptable> semiProcessedList = new List<SemiProcessedScriptable>();
    //public GameObject SemiProcessedObj;

    //public SemiProcessedScriptable FindProcessedOutput(IngredientsScriptable currIngredient)
    //{
    //    SemiProcessedScriptable semiObj = semiProcessedList.FirstOrDefault(obj => obj.ingredient == currIngredient);
        
    //    if(semiObj != null)
    //    {
    //        return semiObj;
    //    } else
    //    {
    //        Debug.Log("No processed found!");
    //        return null;
    //    }
    //}

    ////Spawn Processed Food
    //public GameObject SpawnProcessFood(Vector2 spawnPos, SemiProcessedScriptable semiProcessed)
    //{
    //    GameObject semiProcessedObj = Instantiate(SemiProcessedObj, spawnPos, Quaternion.identity);
    //    semiProcessedObj.GetComponent<SemiProcessed>().semiProcessedScriptable = semiProcessed;
    //    semiProcessedObj.transform.parent = transform;

    //    return semiProcessedObj;
    //}
}
