using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        slider.SetValueWithoutNotify(SoundManager.instance.MusicVolume);
    }

    private void Update()
    {
        SoundManager.instance.SetMusicVolume(slider.value);
    }
}
