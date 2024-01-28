using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : MonoBehaviour
{
    public GameObject cuttingObj;
    private CuttingRoom cuttingRoom;
    public SoundManager soundManager;
    private int SFXindex = 2;

    private void Start()
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
            cuttingObj.GetComponent<Dragable>().SetLastPosition(transform.position);
            GetComponentInParent<Room>().roomElevator.foodObj = null;

        }
        else if (collision.CompareTag("Knife"))
        {
            if (cuttingObj == null) return;
            FoodScriptable ingredient = cuttingObj.GetComponent<FoodHolder>().food;
            FoodScriptable processedObj = cuttingRoom.FindOutputDish(ingredient);

            if (processedObj == null)
            {
                return;
            }

            collision.GetComponent<Dragable>().isDrag = false;
            Destroy(cuttingObj);
            soundManager.PlaySoundEffect(SFXindex);
            cuttingObj = cuttingRoom.ProcessFood(transform.position, processedObj);
        }
    }
}
