using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;
using TMPro;
using System.Linq;

public class Item : MonoBehaviour
{
    public BaseIngredient ingredient;
    private TextMeshPro textMeshPro;
    public Garden garden;

    private void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshPro>();
    }

    private void Update()
    {
        if(textMeshPro != null)
            textMeshPro.text = garden.PlantItems.FirstOrDefault(item => item._ingredient._baseIngredient == ingredient)?._ID;
    }
}
