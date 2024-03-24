using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Pot : MonoBehaviour
{
    public SpriteRenderer potContent;
    public FrySoup frySoup;
    public FoodHolder foodInPot;
    public Sprite waterPot;
    public Sprite oilSprite;
    public int SFXIndex;

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

        if (frySoup.room.roomElevator.foodObj == foodInPot?.gameObject &&
           frySoup.room.roomElevator.foodObj != null)
        {
            foodInPot.plateRenderer.enabled = true;
            foodInPot.drinkRenderer.enabled = true;
            foodInPot.sideRenderer.enabled = true;
            foodInPot = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            foodInPot = collision.GetComponent<FoodHolder>();
            GameObject processedFood = frySoup.ProcessPotFood(foodInPot);
            if (processedFood != null)
            {
                SoundManager.instance.PlaySoundEffect(SFXIndex);
                frySoup.room.roomElevator.foodObj = null;
                processedFood.GetComponent<Dragable>().SetLastPosition(transform);
                processedFood.GetComponent<Dragable>().ResetPosition();
                foodInPot.plateRenderer.enabled = false;
                foodInPot.drinkRenderer.enabled = false;
                foodInPot.sideRenderer.enabled = false;
            }
        }
    }
}
