using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIngridient : MonoBehaviour
{
    [SerializeField] private GameObject Raw;
    [SerializeField] private Transform SpawnPos;

    // Update is called once per frame
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && RawMeat.RawMeatAmount < 1)
        {
            Instantiate(Raw, SpawnPos.position, Quaternion.identity, transform.parent);
        }
    }
}
