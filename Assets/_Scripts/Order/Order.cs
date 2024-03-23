using System.Collections;
using System.Collections.Generic;
using TMPro;
using Types;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    public static int OrderCount;
    public OrderList orderList;
    public FoodScriptable orderDish;
    public bool isOrderFermented = false;

    [SerializeField] public bool IsOrderFermented
    {
        get { return isOrderFermented; }
        set
        {
            if (!orderDish._isFermentable) return;

            isOrderFermented = value;
            switch (value)
            {
                case true:
                    {
                        plateImage.sprite = orderDish._fermentedPlate;
                        break;
                    }
                case false:
                    {
                        plateImage.sprite = orderDish._normalPlate;
                        break;
                    }
            }
        }
    }

    [SerializeField] private DrinkType orderDrink;
    public DrinkType OrderDrink {

        get { return orderDrink; }
        set {
            orderDrink = value;
            switch (value)
            {
                case DrinkType.None:
                    {
                        drinkImage.enabled = false;
                        return;
                    }
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
                default:
                    drinkImage.enabled = false;
                    return;
            }
            drinkImage.enabled = true;
        }
    }
    [SerializeField] private SideDish orderSideDish;
    public SideDish OrderSideDish
    {
        get { return orderSideDish; }
        set {
            orderSideDish = value;
            switch (value)
            {
                case SideDish.None:
                    {
                        sideDishImage.enabled = false;
                        return;
                    }
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
                default:
                    sideDishImage.enabled = false;
                    return;
            }
            sideDishImage.enabled = true;
        }
    }

    public Image orderImage;
    public Image sideDishImage;
    public Image drinkImage;
    public Image plateImage;

    public Slider orderSlider;
    public TextMeshProUGUI orderNameTMP;
    public float currentPatience;

    private void Awake()
    {
        OrderDrink = DrinkType.None;
        OrderSideDish = SideDish.None;
    }

    private void Start()
    {
        gameObject.name = "Order_" + orderDish._foodName;
        orderImage.sprite = orderDish._foodSprite;
        orderNameTMP.text = GetOrderName();
        currentPatience = LevelManager.instance.MaxPatience;
        orderSlider.maxValue = currentPatience;
        StartCoroutine(PatienceCountdown());

        OrderCount++;
    }

    private string GetOrderName() {
        string aged = isOrderFermented ? "Aged " : "";
        string dish = orderDish._foodName;
        string drink;
        string sidedish;

        switch (OrderSideDish)
        {
            case SideDish.CutPotato:
                sidedish = "Potato";
                break;
            case SideDish.CutMushroom:
                sidedish = "Shroom";
                break;
            case SideDish.CutCarrot:
                sidedish = "Carrot";
                break;
            case SideDish.CutCorn:
                sidedish = "Corn";
                break;
            default:
                sidedish = "";
                break;
        }

        switch (OrderDrink)
        {
            case DrinkType.Blue:
                drink = "Blue";
                break;
            case DrinkType.Red:
                drink = "Red";
                break;
            case DrinkType.Green:
                drink = "Green";
                break;
            case DrinkType.Yellow:
                drink = "Yellow";
                break;
            case DrinkType.Purple:
                drink = "Purple";
                break;
            case DrinkType.Orange:
                drink = "Orange";
                break;
            default:
                drink = "";
                break;
        }

        if (string.Compare(sidedish, "") != 0 && string.Compare(drink, "") != 0)
        {
            drink = " | " + drink;
        }

        return aged + dish + "\n" + sidedish + drink;
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

        GameManager.instance.Death(DeathCondition.PatienceGone);
        orderList?.RemoveOrder(this);
    }

    public void OnDestroy()
    {
        OrderCount--;
    }
}
