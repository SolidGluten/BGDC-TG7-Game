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

    public void OnMouseDown()
    {
        if (!gardenItem.isUnlock) return;

        gardenObj = gardenItem.garden.GeneratePlant(ingredient, transform);
        gardenObj.GetComponent<Dragable>().SetDrag();
        isSpawned = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && gardenItem.isUnlock)
        {
            if (gardenObj == gardenItem.garden.room.roomElevator.foodObj) {
                gardenObj = null;
                gardenItem.LockItem();
            }
            else if (isSpawned && gardenItem.garden.room.roomElevator.foodObj != gardenObj) {
                Destroy(gardenObj);
                gardenItem.LockItem();
            }

            isSpawned = false;
        }
    }
}
