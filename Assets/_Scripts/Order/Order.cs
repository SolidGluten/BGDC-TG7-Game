using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    public OrderList orderList;
    public DishScriptable orderDish;
    public Image orderImage;
    public Slider orderSlider;
    public TextMeshProUGUI orderNameTMP;
    public float currentPatience = GameManager.MaxPatience;

    private void Start()
    {
        gameObject.name = "Order_" + orderDish.dishName;
        orderImage.sprite = orderDish.dishSprite;
        orderNameTMP.text = orderDish.dishName;
        orderSlider.maxValue = currentPatience;

        StartCoroutine(PatienceCountdown());
    }

    public IEnumerator PatienceCountdown()
    {
        while(currentPatience > 0)
        {
            currentPatience -= Time.deltaTime;
            orderSlider.value = currentPatience; 
            yield return null;
        }

        //DEATH CONDITION
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        orderList.RemoveOrder(orderDish);
    }
}
