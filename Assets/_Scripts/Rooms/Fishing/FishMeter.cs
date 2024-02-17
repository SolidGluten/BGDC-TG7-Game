using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishMeter : MonoBehaviour
{
    private Slider slider;
    public Fishing fishing;
    public float maxSliderValue;
    public float currentSliderValue;

    private void Start()
    {
        slider = GetComponent<Slider>();
        maxSliderValue = fishing.maxFishTime + fishing.maxTimeBeforeDeath;
    }

    private void Update()
    {
        currentSliderValue = fishing.currentFishTime + fishing.currentTimeBeforeDeath;
        slider.value = currentSliderValue/maxSliderValue;
    }
}
