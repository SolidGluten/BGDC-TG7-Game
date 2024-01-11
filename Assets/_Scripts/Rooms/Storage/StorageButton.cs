using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

public class StorageButton : MonoBehaviour
{
    public BaseIngredient ingredient;
    public Storage storage;

    private void OnMouseDown()
    {
        storage.GetMeat(ingredient);
    }
}
