using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PanCooking : MonoBehaviour
{
    //References
    public FryingPan fryingPan; 
    private SpriteRenderer spriteRenderer;

    //Booleans
    public bool isEmpty = true, isCooked = false, isBurning = false;
   
    [SerializeField] private Sprite readySprite, cookSprite, emptySprite;
    public float CookTime, BurnTime;
    private float currentCookTime, currentBurnTime;

    public IngredientsScriptable currentIngredient;

    public DishScriptable DishOutput;

    void Start()
    {
        ResetTimer();
        spriteRenderer = GetComponent<SpriteRenderer>();
        fryingPan = GetComponentInParent<FryingPan>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isEmpty) return;

        if (other.gameObject.CompareTag("Ingredient"))
        {
            currentIngredient = other.GetComponent<Ingredient>().ingredientsScriptable;
        }
        else return;

        DishOutput = fryingPan.FindOutputDish(currentIngredient);

        if(DishOutput == null)
        {
            return;
        }

        Destroy(other.gameObject);
        isEmpty = false; isCooked = true;
        ChangeSprite(cookSprite);
        Cook();
    }

    private void OnMouseDown()
    {
        if (!isCooked) return;

        fryingPan.ProcessFood(transform.position, DishOutput);
        ChangeSprite(emptySprite);
        isEmpty = true;
        isCooked = false;
        isBurning = false;
        ResetTimer();
    }

    private async void Cook()
    {
        while (currentCookTime > 0)
        {
            currentCookTime -= Time.deltaTime;
            Debug.Log(currentCookTime);
            await Task.Yield();
        }

        ChangeSprite(readySprite);
        isBurning = true;

        while (currentBurnTime > 0 && isBurning)
        {
            currentBurnTime -= Time.deltaTime;
            Debug.Log(currentBurnTime);
            await Task.Yield();
        }

        GameManager.Death((DeathCondition)1);
    }

    //Combined the 3 CookSprite, ReadySprite, & EmptySprite into 1 function
    void ChangeSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    private void ResetTimer()
    {
        currentCookTime = CookTime;
        currentBurnTime = BurnTime;
    }
}
