using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecipeItem : MonoBehaviour
{
    public FoodScriptable food;
    public TextMeshProUGUI textMesh;

    private void Awake()
    {
        textMesh.text = food.name;
    }

}
