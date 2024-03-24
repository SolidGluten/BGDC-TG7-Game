using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatMeter : MonoBehaviour
{
    public Slider readyMeter;
    public Slider readyBackground;
    public FrySoup frySoup;

    public Image HandleImg;
    public Sprite DefaultIcon;
    public Sprite OverIcon;


    private void Start()
    {
        readyMeter.value = 0;
        readyBackground.value = frySoup.rightTemperature / frySoup.maxTemperature;
    }

    private void Update()
    {
        var sliderVal = frySoup.currTemperature/frySoup.maxTemperature;
        readyMeter.value = sliderVal;

        if (sliderVal < readyBackground.value)
        {
            HandleImg.sprite = DefaultIcon;
        }
        else {
            HandleImg.sprite = OverIcon;
        }
    }
}
