using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSlider : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        slider.SetValueWithoutNotify(SoundManager.instance.SFXVolume);
    }

    private void Update()
    {
        SoundManager.instance.SetSFXVolume(slider.value);
    }
}
