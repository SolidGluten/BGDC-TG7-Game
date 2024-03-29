using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

public class StorageButton : InputButton
{
    public BaseIngredient ingredient;
    public Storage storage;
    public GameObject storageObj;
    public bool isSpawn;

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        storageObj = storage.GetMeat(ingredient, transform);
        storageObj.GetComponent<Dragable>().SetDrag();
        isSpawn = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {

            if(storageObj == storage.room.roomElevator.foodObj)
                storageObj = null;
            else if (isSpawn && storage.room.roomElevator.foodObj != storageObj)
                Destroy(storageObj);

            isSpawn = false;
        }
    }
}
