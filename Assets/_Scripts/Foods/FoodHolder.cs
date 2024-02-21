using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class FoodHolder : MonoBehaviour
{
    [SerializeField] private FoodScriptable foodScript;
    public FoodScriptable FoodScript 
    { 
        get { return foodScript; }
        set { 
            foodScript = value;
            foodName = foodScript._foodName;
            sprite = foodScript._foodSprite;
            type = foodScript._foodType;

            if(type == FoodType.SideDish)
            {
                SideDish = value._sideDish;
            }

            baseIngredient = foodScript._baseIngredient;
            semiProcessed = foodScript._semiProcessed;
            dishType = foodScript._dishType;
            this.name = "F_" + foodName;
            foodRenderer.sprite = sprite;
        }
    }

    [SerializeField] public string foodName;
    [SerializeField] public Sprite sprite;
    [SerializeField] public SpriteRenderer plateRenderer;
    [SerializeField] public SpriteRenderer sideRenderer;
    [SerializeField] public SpriteRenderer drinkRenderer;
    [SerializeField] public FoodType type;

    [SerializeField] private bool isFermented;
    [SerializeField] public bool IsFermented
    {
        get { return isFermented; }
        set { 
            isFermented = value;
            switch (value)
            {
                case true:
                    {
                        plateRenderer.sprite =  foodScript._fermentedPlate;
                        break;
                    }
                case false:
                    {
                        plateRenderer.sprite = foodScript._normalPlate;
                        break;
                    }
            }    
        }
    }

    [SerializeField] private DrinkType drink;
    public DrinkType DrinkType
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
                        drinkRenderer.sprite = foodScript._redDrink;
                        break;
                    }
                case DrinkType.Orange:
                    {
                        drinkRenderer.sprite = foodScript._orangeDrink;
                        break;
                    }
                case DrinkType.Yellow:
                    {
                        drinkRenderer.sprite = foodScript._yellowDrink;
                        break;
                    }
                case DrinkType.Green:
                    {
                        drinkRenderer.sprite = foodScript._greenDrink;
                        break;
                    }
                case DrinkType.Blue:
                    {
                        drinkRenderer.sprite = foodScript._blueDrink;
                        break;
                    }
                case DrinkType.Purple:
                    {
                        drinkRenderer.sprite = foodScript._purpleDrink;
                        break;
                    }
                default: { break; }
            }
        }
    }
    [SerializeField] private SideDish sides;
    public SideDish SideDish
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
                        sideRenderer.sprite = foodScript._addCarrot;
                        break;
                    }
                case SideDish.CutPotato:
                    {
                        sideRenderer.sprite = foodScript._addPotato;
                        break;
                    }
                case SideDish.CutMushroom:
                    {
                        sideRenderer.sprite = foodScript._addMushroom;
                        break;
                    }
                case SideDish.CutCorn:
                    {
                        sideRenderer.sprite = foodScript._addCorn;
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

    private void Awake()
    {
        foodRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        foodName = foodScript._foodName;
        sprite = foodScript._foodSprite;
        type = foodScript._foodType;
        drink = foodScript._drink;
        SideDish = foodScript._sideDish;
        baseIngredient = foodScript._baseIngredient;
        semiProcessed = foodScript._semiProcessed;
        dishType = foodScript._dishType;

        this.name = "F_" + foodName;
        foodRenderer.sprite = sprite;
    }
}
