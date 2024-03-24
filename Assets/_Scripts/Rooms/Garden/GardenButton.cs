using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

public class GardenButton : MonoBehaviour
{
    public BaseIngredient ingredient;
    public Item gardenItem;
    public GameObject gardenObj;
    public bool isSpawned;
    public static int amount = 0;

    public void OnMouseDown()
    {
        if (amount > 0) return;
        gardenObj = gardenItem.garden.GeneratePlant(ingredient, transform);
        gardenObj.GetComponent<Dragable>().SetDrag();
        isSpawned = true;
        amount++;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (gardenObj == null) return;

            if (gardenObj == gardenItem.garden.room.roomElevator.foodObj) {
                gardenObj = null;
                gardenItem.LockItem();
            }
            else if (isSpawned && gardenItem.garden.room.roomElevator.foodObj != gardenObj) {
                Destroy(gardenObj);
                gardenItem.LockItem();
            }
            amount--;

            isSpawned = false;
        }
    }
}
