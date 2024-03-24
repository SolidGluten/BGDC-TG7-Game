using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class TutorialPanel : MonoBehaviour
{
    public Sprite DefaultLight;
    public Sprite OnLight;
    public Image LightImage;

    public bool isAlert = false;
    public bool isLightUp = false;

    private Button button;

    public static TutorialPanel instance;

    public int SFXIndex = 13;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
            instance = this;
    }

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(StopAlert);
    }

    [ContextMenu("Show Alert")]
    public void ShowAlert(){
        isAlert = true;
        InvokeRepeating("Blink", 0, 0.4f);
        SoundManager.instance.PlaySoundEffect(SFXIndex);
        SoundManager.instance.SetSoundEffectLoop(SFXIndex);
    }

    [ContextMenu("Stop Alert")]
    private void StopAlert() {
        isAlert = false;
        CancelInvoke("Blink");
        LightImage.sprite = DefaultLight;
        SoundManager.instance.StopSoundEffect(SFXIndex);
    }

    private void Blink() {
        isLightUp = !isLightUp;
        LightImage.sprite = isLightUp ? OnLight : DefaultLight;
    }
}
