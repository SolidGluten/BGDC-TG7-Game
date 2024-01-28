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
    [SerializeField] public FoodType type;
    [SerializeField] public DrinkType drinks;
    [SerializeField] private SideDish sides;
    public SideDish sideDish
    {
        get { return sides; }
        set
        {
            sides = value;
            if(type == FoodType.Dish)
            {
                switch (value)
                {
                    case SideDish.None:
                        {
                            break;
                        }
                    case SideDish.CutCarrot:
                        {
                            sprite = addCarrot;
                            UpdateSprite();
                            break;
                        }
                    case SideDish.CutPotato:
                        {
                            sprite = addPotato;
                            UpdateSprite();
                            break;
                        }
                    case SideDish.CutMushroom:
                        {
                            sprite = addMushroom;
                            UpdateSprite();
                            break;
                        }
                    case SideDish.CutCorn:
                        {
                            sprite = addCorn;
                            UpdateSprite();
                            break;
                        }
                    default: { break; }
                }
            }
        }
    }
    [SerializeField] public BaseIngredient baseIngredient;
    [SerializeField] public SemiProcessed semiProcessed;
    [SerializeField] public DishType dishType;
    private Sprite addPotato;
    private Sprite addCarrot;
    private Sprite addCorn;
    private Sprite addMushroom;

    private SpriteRenderer foodRenderer;

    private void Start()
    {
        foodRenderer = GetComponent<SpriteRenderer>();

        foodName = food._foodName;
        sprite = food._foodSprite;
        type = food._foodType;
        drinks = food._drinks;
        sideDish = food._sideDish;
        baseIngredient = food._baseIngredient;
        semiProcessed = food._semiProcessed;
        dishType = food._dishType;
        addCarrot = food._addCarrot;
        addPotato = food._addPotato;
        addCorn = food._addCorn;
        addMushroom = food._addMushroom;

        this.name = "F_" + foodName;
        foodRenderer.sprite = sprite;
    }

    private void UpdateSprite()
    {
        foodRenderer.sprite = sprite;
    }
}
