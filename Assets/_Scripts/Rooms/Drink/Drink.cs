using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

public class Drink : Generator
{
    public Color currentColor = Color.black;
    public DrinkType currentDrink = DrinkType.None;
    [SerializeField] private int colorAdded = 0;

    public void AddRed()
    {
        if (colorAdded == 2 || currentColor == Color.red) return;
        else if (colorAdded == 0)
            currentColor = Color.red;
        colorAdded++;
        ChangeDrink(DrinkType.Red);
    }

    public void AddYellow()
    {
        if (colorAdded == 2 || currentColor == Color.yellow) return;
        else if (colorAdded == 0)
            currentColor = Color.yellow;
        colorAdded++;
        ChangeDrink(DrinkType.Yellow);  
    }

    public void AddBlue()
    {
        if (colorAdded == 2 || currentColor == Color.blue) return;
        else if (colorAdded == 0)
            currentColor = Color.blue;
        colorAdded++;
        ChangeDrink(DrinkType.Blue);
    }

    public void ChangeDrink(DrinkType type)
    {
        switch (currentDrink) {
            case DrinkType.None:
                {
                    currentDrink = type;
                    break;
                }
            case DrinkType.Red:
                {
                    if (type == DrinkType.Yellow)
                    {
                        currentDrink = DrinkType.Orange;
                        currentColor = new Color32(255, 166, 0, 255); //Orange RGB
                    }
                    else if (type == DrinkType.Blue)
                    {
                        currentDrink = DrinkType.Purple;
                        currentColor = new Color32(160, 32, 240, 255); //Purples RGB
                    }
                    break;
                }
            case DrinkType.Yellow:
                {
                    if (type == DrinkType.Red)
                    {
                        currentDrink = DrinkType.Orange;
                        currentColor = new Color32(255, 166, 0, 255); //Orange RGB
                    }
                    else if (type == DrinkType.Blue)
                    {
                        currentDrink = DrinkType.Green;
                        currentColor = new Color32(0, 255, 0, 255); //Green RGB
                    }
                    break;
                }
            case DrinkType.Blue:
                {
                    if (type == DrinkType.Yellow)
                    {
                        currentDrink = DrinkType.Green;
                        currentColor = new Color32(0, 255, 0, 255); //Green RGB
                    }
                    else if (type == DrinkType.Red)
                    {
                        currentDrink = DrinkType.Purple;
                        currentColor = new Color32(160, 32, 240, 255); //Orange RGB
                    }
                    break;
                }
            default: break;
        }
    }

    public void ResetColor()
    {
        colorAdded = 0;
        currentColor = Color.white;
        currentDrink = DrinkType.None;
    }

    public void DispenseDrink()
    {
        FoodScriptable drink = FindBeverage(currentDrink);
        if(drink == null)
        {
            Debug.Log("Drink Not Found!");
            return;
        }
        GenerateIngredient(drink);
        ResetColor();
    }
}
    