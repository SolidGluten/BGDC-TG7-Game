using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Pot : MonoBehaviour
{
    private SpriteRenderer potRenderer;
    public FrySoup frySoup;
    public Sprite waterPot;
    public Sprite oilSprite;

    private void Start()
    {
        potRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (frySoup.currentType == PotType.Water)
        {
            potRenderer.sprite = waterPot;
            potRenderer.color = Color.blue;
        }
        else
        {
            potRenderer.sprite = oilSprite;
            potRenderer.color = Color.red;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            FoodHolder food = collision.GetComponent<FoodHolder>();
            GameObject processedFood = frySoup.ProcessPotFood(food);
            if (processedFood != null)
            {
                frySoup.room.roomElevator.foodObj = null;
                processedFood.GetComponent<Dragable>().SetLastPosition(transform);
                processedFood.GetComponent<Dragable>().ResetPosition();
            }
        }
    }
}
