using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishMeter : MonoBehaviour
{
    public Fishing fishing;
    public Slider readyMeter;
    public Slider readyBackground;
    public Image HandleImg;
    public Sprite DefaultIcon;
    public Sprite OverIcon;

    private float maxSliderValue;
    private float currentSliderValue;

    private void Start()
    {
        maxSliderValue = fishing.maxFishTime + fishing.maxTimeBeforeDeath;
        readyBackground.value = fishing.maxFishTime/maxSliderValue;
    }

    private void Update()
    {
        currentSliderValue = fishing.currentFishTime + fishing.currentTimeBeforeDeath;
        readyMeter.value = currentSliderValue/maxSliderValue;

        if (currentSliderValue/maxSliderValue < readyBackground.value)
        {
            HandleImg.sprite = DefaultIcon;
        }
        else{
            HandleImg.sprite = OverIcon;
        }
    }
}
