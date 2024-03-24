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
    public GameObject glassCover;
    public Garden garden;
    public string currentId;
    public bool isUnlock = false;

    public Sprite[] AlphaIcons = new Sprite[4];
    public Sprite[] NumberIcons = new Sprite[4];

    public void UpdateID(string id){
        currentId = id;

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
                number.sprite = NumberIcons[0];
                break;
            case '2':
                number.sprite = NumberIcons[1];
                break;
            case '3':
                number.sprite = NumberIcons[2];
                break;
            case '4':
                number.sprite = NumberIcons[3];
                break;
        }
    }

    public void UnlockItem() {
        isUnlock = true;
        garden.isSlotOpen = true;
        glassCover.SetActive(false);
    }

    public void LockItem() {
        isUnlock = false;
        garden.isSlotOpen = false;
        glassCover.SetActive(true);
        garden.RandomizeAllID();
    }
}
