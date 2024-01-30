using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatMeter : MonoBehaviour
{
    private Slider slider;
    public FrySoup frySoup;
    public Image fillRect;
    [SerializeField] private Color initialColor;
    [SerializeField] private Color rightColor;
    [SerializeField] private Color finalColor;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 0;
    }

    private void Update()
    {
        var sliderVal = frySoup.currTemperature/frySoup.maxTemperature;
        slider.value = sliderVal;

        var intitialToRightVal = frySoup.currTemperature / frySoup.rightTemperature;
        var rightToFinalVal = (frySoup.currTemperature - frySoup.rightTemperature) / (frySoup.maxTemperature - frySoup.rightTemperature);
        if(frySoup.currTemperature < frySoup.rightTemperature)
            fillRect.color = Color.Lerp(initialColor, rightColor, intitialToRightVal);
        else
            fillRect.color = Color.Lerp(rightColor, finalColor, rightToFinalVal);
    }
}
