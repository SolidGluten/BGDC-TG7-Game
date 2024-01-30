using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FermentationRoom : Processor
{
    [SerializeField] private float maxFermentationTime;
    [SerializeField] private float currentFermentationTime = 0;

    public void Ferment(Transform spawnPoint, FoodScriptable raw)
    {
        StartCoroutine(I_Ferment(spawnPoint, raw));
    }

    private IEnumerator I_Ferment(Transform spawnPoint, FoodScriptable raw)
    {
        while(currentFermentationTime < maxFermentationTime)
        {
            currentFermentationTime += Time.deltaTime;
            yield return null;
        }

        GameObject fermentedFood = ProcessFood(spawnPoint.position, raw);
        fermentedFood.GetComponent<Dragable>().SetLastPosition(spawnPoint);
        currentFermentationTime = 0;
    }
}
