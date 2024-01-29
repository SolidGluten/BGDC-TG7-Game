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
        fillRect.color = Color.Lerp(initialColor, finalColor, sliderVal);

    }
}
