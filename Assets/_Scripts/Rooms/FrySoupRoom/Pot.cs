using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Pot : MonoBehaviour
{
    public SpriteRenderer potContent;
    public FrySoup frySoup;
    public Sprite waterPot;
    public Sprite oilSprite;

    private void Update()
    {
        if (frySoup.currentType == PotType.Water)
        {
            potContent.sprite = waterPot;
        }
        else
        {
            potContent.sprite = oilSprite;
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
