using System.Collections;
using System.Collections.Generic;
using TMPro;
using Types;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    public OrderList orderList;
    public FoodScriptable orderDish;
    [SerializeField] private DrinkType orderDrink;
    public DrinkType OrderDrink {

        get { return orderDrink; }
        set {
            orderDrink = value;
            drinkImage.gameObject.SetActive(true);
            switch (value)
            {
                case DrinkType.Red:
                    {
                        drinkImage.sprite = orderDish._redDrink;
                        break;
                    }
                case DrinkType.Orange:
                    {
                        drinkImage.sprite = orderDish._orangeDrink;
                        break;
                    }
                case DrinkType.Yellow:
                    {
                        drinkImage.sprite = orderDish._yellowDrink;
                        break;
                    }
                case DrinkType.Green:
                    {
                        drinkImage.sprite = orderDish._greenDrink;
                        break;
                    }
                case DrinkType.Blue:
                    {
                        drinkImage.sprite = orderDish._blueDrink;
                        break;
                    }
                case DrinkType.Purple:
                    {
                        drinkImage.sprite = orderDish._purpleDrink;
                        break;
                    }
                default: break;
            }
        }
    }
    [SerializeField] private SideDish orderSideDish;
    public SideDish OrderSideDish
    {
        get { return orderSideDish; }
        set {
            orderSideDish = value;
            sideDishImage.gameObject.SetActive(true);
            switch (value)
            {
                case SideDish.CutCarrot:
                    {
                        sideDishImage.sprite = orderDish._addCarrot;
                        break;
                    }
                case SideDish.CutPotato:
                    {
                        sideDishImage.sprite = orderDish._addPotato;
                        break;
                    }
                case SideDish.CutMushroom:
                    {
                        sideDishImage.sprite = orderDish._addMushroom;
                        break;
                    }
                case SideDish.CutCorn:
                    {
                        sideDishImage.sprite = orderDish._addCorn;
                        break;
                    }
                default: break;
            }
        }
    }

    public Image orderImage;
    public Image sideDishImage;
    public Image drinkImage;

    public Slider orderSlider;
    public TextMeshProUGUI orderNameTMP;
    public float currentPatience;

    private void Start()
    {
        gameObject.name = "Order_" + orderDish._foodName;
        orderImage.sprite = orderDish._foodSprite;
        orderNameTMP.text = orderDish._foodName;
        currentPatience = LevelManager.instance.MaxPatience;
        orderSlider.maxValue = currentPatience;
        StartCoroutine(PatienceCountdown());
    }

    public void SetRandomDrink()
    {
        OrderDrink = TypeUtils.GetRandomDrink();
    }

    public void SetRandomSides()
    {
        OrderSideDish = TypeUtils.GetRandomSideDish();
    }

    public IEnumerator PatienceCountdown()
    {
        while (currentPatience > 0)
        {
            currentPatience -= Time.deltaTime;
            orderSlider.value = currentPatience;
            yield return null;
        }

        //DEATH CONDITION
        orderList?.RemoveOrder(this);
    }
}
