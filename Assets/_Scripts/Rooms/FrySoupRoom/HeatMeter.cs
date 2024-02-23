using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatMeter : MonoBehaviour
{
    public Slider readyMeter;
    public Slider readyBackground;
    public FrySoup frySoup;

    private void Start()
    {
        readyMeter.value = 0;
        readyBackground.value = frySoup.rightTemperature / frySoup.maxTemperature;
    }

    private void Update()
    {
        var sliderVal = frySoup.currTemperature/frySoup.maxTemperature;
        readyMeter.value = sliderVal;
    }
}
