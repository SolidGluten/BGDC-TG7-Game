using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    public OrderList orderList;
    public FoodScriptable orderDish;
    public Image orderImage;
    public Slider orderSlider;
    public TextMeshProUGUI orderNameTMP;
    public float currentPatience = GameManager.MaxPatience;

    private void Start()
    {
        gameObject.name = "Order_" + orderDish._foodName;
        orderImage.sprite = orderDish._foodSprite;
        orderNameTMP.text = orderDish._foodName;
        orderSlider.maxValue = currentPatience;

        StartCoroutine(PatienceCountdown());
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
        orderList?.RemoveOrder(orderDish);
    }
}
