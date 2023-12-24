using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    public Image orderImage;
    public TextMeshProUGUI orderNameTMP;
    public DishScriptable dishOrder;
    public Slider patienceBar;

    public float currentPatience;
    public float maxPatience;

    private void Start()
    {
        maxPatience = GameManager.MaxPatience;
        currentPatience = maxPatience;
        patienceBar.maxValue = maxPatience;

        gameObject.name = "Order_" + dishOrder.dishName;
        orderNameTMP.text = dishOrder.dishName;
        orderImage.sprite = dishOrder.dishSprite;
    }

    private void Update()
    {
        if(currentPatience > 0)
        {
            currentPatience -= Time.deltaTime;
            patienceBar.value = currentPatience;
            
        } else
        {
            Destroy(gameObject);
            //INSERT DEATH CONDITION HERE!
        }
    }
}
