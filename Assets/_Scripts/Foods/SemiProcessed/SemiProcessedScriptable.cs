using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenu(menuName = "Food/NewSemiProcessed")]
public class SemiProcessedScriptable : ScriptableObject
{
    public string semiProcessedName;
    public Sprite semiProcessedSprite;
    public ProcessType processType;
    public IngredientsScriptable ingredient;
}
