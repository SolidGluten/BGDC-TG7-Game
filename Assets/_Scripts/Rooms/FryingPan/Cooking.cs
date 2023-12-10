using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    private bool isEmpty, isCooked;
    new Collider2D collider;
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
        collider = GetComponent<Collider2D>();
        isEmpty = true;
        isCooked = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Do u need this? If so then put it into the update so it can always keep track of the mouse po
        //mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

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
        if (other.gameObject.CompareTag("Raw") && Input.GetMouseButtonUp(0))
        {
            isEmpty = false;
        }
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && currentCookTime <= 0)
        {
            Instantiate(Cooked, transform.position, Quaternion.identity);
            isEmpty = true;
            isCooked = true;
            ChangeSprite(oldSprite);
        }
    }

    void Cook()
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
