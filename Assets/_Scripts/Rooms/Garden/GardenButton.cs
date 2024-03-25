using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

public class GardenButton : MonoBehaviour
{
    public BaseIngredient ingredient;
    public Item gardenItem;
    public GameObject gardenObj;

    public void OnMouseDown()
    {
        if (!gardenItem.isUnlock) return;
        gardenObj = gardenItem.garden.GeneratePlant(ingredient, transform);
        gardenObj.GetComponent<Dragable>().SetDrag();
    }

    private void OnMouseUp()
    {
        if (!gardenItem.isUnlock) return;

        if (gardenObj == gardenItem.garden.room.roomElevator.foodObj) {
            gardenObj = null;
            gardenItem.LockItem();
        }
        else if (gardenItem.garden.room.roomElevator.foodObj != gardenObj) {
            Destroy(gardenObj);
            gardenItem.LockItem();
        }
    }
}
