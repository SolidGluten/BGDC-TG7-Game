using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFood", menuName = "Food/Add Food")]
public class FoodScriptable : ScriptableObject
{
    [SerializeField] public string _foodName;
    [SerializeField] public Sprite _foodSprite;
    [SerializeField] public FoodType _foodType;
    [SerializeField] public DrinkType _drinks;
    [SerializeField] public SideDish _sideDish;
    [SerializeField] public BaseIngredient _baseIngredient;
    [SerializeField] public SemiProcessed _semiProcessed;
    [SerializeField] public DishType _dishType;
    [SerializeField] public Sprite _addPotato;
    [SerializeField] public Sprite _addCarrot;
    [SerializeField] public Sprite _addCorn;
    [SerializeField] public Sprite _addMushroom;
}
