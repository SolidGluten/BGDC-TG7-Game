using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIngridient : MonoBehaviour
{
    [SerializeField] private GameObject Raw;

    // Update is called once per frame
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Raw, transform.position, Quaternion.identity);
        }
    }
}
