using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FermentationRoom : Processor
{
    public Room room;
    [SerializeField] private float maxFermentationTime;
    [SerializeField] private float currentFermentationTime = 0;

    private void Start()
    {
        room = GetComponentInParent<Room>();
    }

    public IEnumerator Ferment(FoodHolder raw)
    {
        while(currentFermentationTime < maxFermentationTime)
        {
            currentFermentationTime += Time.deltaTime;
            yield return null;
        }

        raw.GetComponent<FoodHolder>().IsFermented = true;
        currentFermentationTime = 0;
    }
}
