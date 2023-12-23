using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject foodObj;

    private void OnEnable()
    {
        if (foodObj != null)
        {
            foodObj.GetComponent<Dragable>().SetLastPosition(transform.position);
            foodObj.GetComponent<Dragable>().ResetPosition();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ingredient") || collision.CompareTag("Dish"))
        {
            foodObj = collision.gameObject;
            foodObj.GetComponent<Dragable>().SetLastPosition(transform.position);
        }
    }
}
