using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    private bool isEmpty;
    new Collider2D collider;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite readySprite;
    [SerializeField] private Sprite cookSprite;
    [SerializeField] private Sprite oldSprite;
    private float cookTime = 5;
    private float burnTime = 5;
    [SerializeField] private GameObject Cooked;
    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    void Start()
    {
        collider = GetComponent<Collider2D>();
        isEmpty = true;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    //void OnCollisionStay2D(Collision other)
    //{
    //    if (other.gameObject.CompareTag("Raw") && Input.GetMouseButtonUp(0))
    //    {
    //        isEmpty = false;
    //        Debug.Log("Inside");
    //    }
    //}
    void Update()
    {
        //Idk how to check if the raw meat is inside the pan collider, used OnCollisionStay2D but it didnt work (might just be me using it wrong)
        if (isEmpty == false)
        {
            Cook();
            Reset();
        }
    }

    void Cook()
    {
        if (cookTime > 0)
        {
            CookSprite();
            cookTime -= Time.deltaTime;
        }
        else
        {
            if (burnTime > 0)
            {
                ReadySprite();
                burnTime -= Time.deltaTime;

                if (Input.GetMouseButtonDown(0))
                {
                    if (collider == Physics2D.OverlapPoint(mousePos))
                    {
                        Instantiate(Cooked, transform.position, Quaternion.identity);
                        isEmpty = true;
                        EmptySprite();
                    } 
                }
            }
            else
            {
                //Lose(); Do this later
            }
        }
    }

    void CookSprite()
    {
        spriteRenderer.sprite = cookSprite;
    }
    void ReadySprite()
    {
        spriteRenderer.sprite = readySprite;
    }
    void EmptySprite()
    {
        spriteRenderer.sprite = oldSprite;
    }
    private void Reset()
    {
        burnTime = 5;
        cookTime = 5;
    }

}
