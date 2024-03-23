using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PanCooking : MonoBehaviour
{
    //References
    public FryingPan fryingPan;

    //Booleans
    public bool isEmpty = true, isCooking = false, isBurning = false;

    [SerializeField] private Sprite readySprite, cookSprite, emptySprite;
    public float CookTime, BurnTime;
    private float currentCookTime, currentBurnTime;

    private FoodHolder foodInPan;
    private FoodScriptable processedFood;

    private int SFXindex = 1;
    void Start()
    {
        ResetTimer();
        fryingPan = GetComponentInParent<FryingPan>();
    }

    private void Update()
    {
        if(fryingPan.room.roomElevator.foodObj == foodInPan?.gameObject &&
           fryingPan.room.roomElevator.foodObj != null)
        {
            SoundManager.instance.StopSoundEffect(SFXindex);
            foodInPan = null;
            isEmpty = true;
            isCooking = false;
            isBurning = false;
            ResetTimer();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isEmpty) return;

        if (other.gameObject.CompareTag("Food"))
        {
            foodInPan = other.GetComponent<FoodHolder>();
            processedFood = fryingPan.FindOutputDish(foodInPan.FoodScript);   
        }

        if(processedFood == null)
        {
            Debug.Log("No dish found!");
            foodInPan = null;
            return;
        }

        fryingPan.room.roomElevator.foodObj = null;
        other.GetComponent<Dragable>().SetLastPosition(transform);
        other.GetComponent<Dragable>().ResetPosition();
        other.GetComponent<Dragable>().dragEnabled = false;
        isEmpty = false; isCooking = true;
        //ChangeSprite(cookSprite);
        StartCoroutine(Cook());
    }

    private void OnMouseDown()
    {
        if (isCooking || isEmpty) return;

        //ChangeSprite(emptySprite);
        isEmpty = true;
        isCooking = false;
        isBurning = false;
        ResetTimer();
    }

    private IEnumerator Cook()
    {
        SoundManager.instance.PlaySoundEffect(SFXindex);
        while (currentCookTime > 0)
        {
            currentCookTime -= Time.deltaTime;
            Debug.Log(currentCookTime);
            yield return null;
        }

        //ChangeSprite(readySprite);
        isCooking = false;
        isBurning = true;

        fryingPan.ProcessFood(foodInPan, processedFood);
        foodInPan.GetComponent<Dragable>().dragEnabled = true;
        foodInPan.GetComponent<Dragable>().SetLastPosition(transform);
        foodInPan.GetComponent<Dragable>().ResetPosition();

        while (currentBurnTime > 0 && isBurning)
        {
            currentBurnTime -= Time.deltaTime;
            Debug.Log(currentBurnTime);
            yield return null;
        }
        if(currentBurnTime <= 0)
        {
            GameManager.instance.Death(DeathCondition.Frying);
        }
    }

    //Combined the 3 CookSprite, ReadySprite, & EmptySprite into 1 function
    //void ChangeSprite(Sprite sprite)
    //{
    //    spriteRenderer.sprite = sprite;
    //}

    private void ResetTimer()
    {
        currentCookTime = CookTime;
        currentBurnTime = BurnTime;
    }
}
