using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    public bool isEmpty, isCooked, isBurning = false;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite readySprite;
    [SerializeField] private Sprite cookSprite;
    [SerializeField] private Sprite emptySprite;
    public float CookTime, BurnTime;
    private float currentCookTime, currentBurnTime;

    [SerializeField] private GameObject CookedMeatPrefab;

    void Start()
    {
        isEmpty = true;
        isCooked = false;
        ResetTimer();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Raw") && isEmpty)
        {
            Destroy(other.gameObject);
            isEmpty = false;
            isCooked = true;
            ChangeSprite(cookSprite);
            Cook();
        }
    }

    private void OnMouseDown()
    {
        if (!isCooked) return;
        GameObject cooked = Instantiate(CookedMeatPrefab, transform.position, Quaternion.identity, transform.parent);
        ChangeSprite(emptySprite);
        isEmpty = true;
        isCooked = false;
        isBurning = false;
        ResetTimer();
    }

    private async void Cook()
    {
        while(currentCookTime > 0)
        {
            currentCookTime -= Time.deltaTime;
            Debug.Log(currentCookTime);
            await Task.Yield();
        }

        ChangeSprite(readySprite);
        isBurning = true;

        while(currentBurnTime > 0 && isBurning)
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
