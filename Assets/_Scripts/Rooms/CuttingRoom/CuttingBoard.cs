using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : MonoBehaviour
{
    public GameObject cuttingObj;
    private CuttingRoom cuttingRoom;
    private int SFXindex = 2;

    private FoodHolder foodOnCuttingBoard;
    private FoodScriptable processedFood;
    private void Awake()
    {
        cuttingRoom = GetComponentInParent<CuttingRoom>();
    }

    private void Update()
    {
        if (cuttingRoom.room.roomElevator.foodObj == cuttingObj)
        {
            cuttingObj = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            if (cuttingObj != null) return;
            cuttingObj = collision.gameObject;
            cuttingObj.GetComponent<Dragable>().SetLastPosition(transform);
            GetComponentInParent<Room>().roomElevator.foodObj = null;

            foodOnCuttingBoard = cuttingObj.GetComponent<FoodHolder>();
        }
        else if (collision.CompareTag("Knife"))
        {
            if (cuttingObj == null) return;

            foodOnCuttingBoard = cuttingObj.GetComponent<FoodHolder>();
            processedFood = cuttingRoom.FindOutputDish(foodOnCuttingBoard.FoodScript);
            if (processedFood == null) return;

            collision.GetComponent<Dragable>().isDrag = false;
            SoundManager.instance.PlaySoundEffect(SFXindex);
            cuttingObj = cuttingRoom.ProcessFood(foodOnCuttingBoard, processedFood);
        }
    }
}
