using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;
using System.Threading.Tasks;
using System.Threading;

public class Fishing : Generator
{
    public float maxFishingTime;
    public float maxTimeBeforeDeath;
    [SerializeField] float currentFishingTime;
    [SerializeField] float currentTimeBeforeDeath;

    public IEnumerator Fish()
    {
        currentFishingTime = maxFishingTime;
        currentTimeBeforeDeath = maxTimeBeforeDeath;

        while(currentFishingTime > 0)
        {
            currentFishingTime -= Time.deltaTime;
            Debug.Log(currentFishingTime);
            yield return null;
        }

        GenerateIngredient();

        while(currentTimeBeforeDeath > 0 && ingredientHolder.ingredient != null)
        {
            currentTimeBeforeDeath -= Time.deltaTime;
            Debug.Log(currentTimeBeforeDeath);
            yield return null;
        }
    }
}
