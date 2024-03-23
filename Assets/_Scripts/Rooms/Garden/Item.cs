using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;
using TMPro;
using System.Linq;

public class Item : MonoBehaviour
{
    public BaseIngredient ingredient;
    public SpriteRenderer alpha;
    public SpriteRenderer number;
    public Garden garden;

    public Sprite[] AlphaIcons = new Sprite[4];
    public Sprite[] NumberIcons = new Sprite[4];

    private void Update()
    {
        var id = garden.PlantItems.FirstOrDefault(item => item._ingredient._baseIngredient == ingredient)?._ID;
        UpdateID(id);
    }

    private void UpdateID(string id){
        switch (id[0])
        {
            case 'A':
                alpha.sprite = AlphaIcons[0];
                break;
            case 'B':
                alpha.sprite = AlphaIcons[1];
                break;
            case 'C':
                alpha.sprite = AlphaIcons[2];
                break;
            case 'D':
                alpha.sprite = AlphaIcons[3];
                break;
        }

        switch (id[1])
        {
            case '1':
                alpha.sprite = AlphaIcons[0];
                break;
            case '2':
                alpha.sprite = AlphaIcons[1];
                break;
            case '3':
                alpha.sprite = AlphaIcons[2];
                break;
            case '4':
                alpha.sprite = AlphaIcons[3];
                break;
        }
    }
}
