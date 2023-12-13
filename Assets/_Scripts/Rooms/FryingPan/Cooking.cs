using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    private bool isEmpty, isCooked;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite readySprite;
    [SerializeField] private Sprite cookSprite;
    [SerializeField] private Sprite oldSprite;
    public float CookTime, BurnTime;

    private float currentCookTime, currentBurnTime;
    [SerializeField] private GameObject Cooked;

    Camera mainCam;
    Vector2 mousePos;

    void Start()
    {
        Reset();
        mainCam = Camera.main;
        isEmpty = true;
        isCooked = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Idk how to check if the raw meat is inside the pan collider, used OnCollisionStay2D but it didnt work (might just be me using it wrong)
        //It's good lmao
        if (isEmpty == false)
        {
            Cook();
        }
        if (isCooked == true)
        {
            Reset();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Raw") && isEmpty)
        {
            Destroy(other.gameObject);
            isEmpty = false;
        }
    }

    private void OnMouseDown()
    {
        if (currentCookTime <= 0)
        {
            Instantiate(Cooked, transform.position, Quaternion.identity, transform.parent);
            isEmpty = true; isCooked = true;
            ChangeSprite(oldSprite);
        }
    }

    private void Cook()
    {
        if (currentCookTime > 0)
        {
            ChangeSprite(cookSprite);
            currentCookTime -= Time.deltaTime;
            Debug.Log(currentCookTime);
        }
        else
        {
            if (currentBurnTime > 0)
            {
                ChangeSprite(readySprite);
                currentBurnTime -= Time.deltaTime;
            }
            else
            {
                //Lose(); Do this later
            }
        }
    }

    //Combined the 3 CookSprite, ReadySprite, & EmptySprite into 1 function
    void ChangeSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    private void Reset()
    {
        currentCookTime = CookTime;
        currentBurnTime = BurnTime;
    }

}
