using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent (typeof(Rigidbody2D))]
public class OrderChute : MonoBehaviour
{
    public GameObject orderHolder;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dish") || collision.CompareTag("ComboDish"))
        {
            Destroy(collision.gameObject);
        }
        else
        {
            Destroy(collision.gameObject);
            //Death Condition
        }
    }

}
