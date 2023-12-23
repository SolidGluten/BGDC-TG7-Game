using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiProcessed : MonoBehaviour
{
    public SemiProcessedScriptable semiProcessedScriptable;

    private void Start()
    {
        gameObject.name = semiProcessedScriptable.semiProcessedName;
        GetComponent<SpriteRenderer>().sprite = semiProcessedScriptable.semiProcessedSprite;
    }
}
