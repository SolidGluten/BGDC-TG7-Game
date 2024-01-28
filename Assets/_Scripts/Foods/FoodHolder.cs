using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class FoodHolder : MonoBehaviour
{
    [SerializeField] public FoodScriptable food;
    [SerializeField] public string foodName;
    [SerializeField] public Sprite sprite;
    [SerializeField] public SpriteRenderer sideRenderer;
    [SerializeField] public SpriteRenderer drinkRenderer;
    [SerializeField] public FoodType type;
    [SerializeField] private DrinkType drink;
    public DrinkType drinkType
    {
        get { return drink; }
        set { 
            drink = value;
            switch (value)
            {
                case DrinkType.None:
                    {
                        break;
                    }
                case DrinkType.Red:
                    {
                        drinkRenderer.sprite = food._redDrink;
                        break;
                    }
                case DrinkType.Orange:
                    {
                        drinkRenderer.sprite = food._orangeDrink;
                        break;
                    }
                case DrinkType.Yellow:
                    {
                        drinkRenderer.sprite = food._yellowDrink;
                        break;
                    }
                case DrinkType.Green:
                    {
                        drinkRenderer.sprite = food._greenDrink;
                        break;
                    }
                case DrinkType.Blue:
                    {
                        drinkRenderer.sprite = food._greenDrink;
                        break;
                    }
                case DrinkType.Purple:
                    {
                        drinkRenderer.sprite = food._purpleDrink;
                        break;
                    }
                default: { break; }
            }
        }
    }
    [SerializeField] private SideDish sides;
    public SideDish sideDish
    {
        get { return sides; }
        set
        {
            sides = value;
            switch (value)
            {
                case SideDish.None:
                    {
                        break;
                    }
                case SideDish.CutCarrot:
                    {
                        sideRenderer.sprite = food._addCarrot;
                        break;
                    }
                case SideDish.CutPotato:
                    {
                        sideRenderer.sprite = food._addPotato;
                        break;
                    }
                case SideDish.CutMushroom:
                    {
                        sideRenderer.sprite = food._addMushroom;
                        break;
                    }
                case SideDish.CutCorn:
                    {
                        sideRenderer.sprite = food._addCorn;
                        break;
                    }
                default: { break; }
            }
        }
    }
    [SerializeField] public BaseIngredient baseIngredient;
    [SerializeField] public SemiProcessed semiProcessed;
    [SerializeField] public DishType dishType;

    private SpriteRenderer foodRenderer;

    private void Start()
    {
        foodRenderer = GetComponent<SpriteRenderer>();

        foodName = food._foodName;
        sprite = food._foodSprite;
        type = food._foodType;
        drink = food._drink;
        sideDish = food._sideDish;
        baseIngredient = food._baseIngredient;
        semiProcessed = food._semiProcessed;
        dishType = food._dishType;

        this.name = "F_" + foodName;
        foodRenderer.sprite = sprite;
    }
}
