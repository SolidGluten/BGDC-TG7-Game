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
    public Fishing fishing;

    private void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshPro>();
    }

    private void Update()
    {
        textMeshPro.text = fishing.fishItems.FirstOrDefault(item => item._ingredient._baseIngredient == ingredient)?._ID;
    }
}
