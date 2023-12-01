using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIngridient : MonoBehaviour
{
    [SerializeField] private GameObject Ingridient;

    // Update is called once per frame
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Ingridient, transform.position, Quaternion.identity);
        }
    }
}
