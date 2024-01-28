using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SendButton : MonoBehaviour
{
    public UnityEvent onButtonPressed;
    public SoundManager soundManager;
    private int SFXindex = 0;
    private void OnMouseDown()
    {
        onButtonPressed.Invoke();
        soundManager.PlaySoundEffect(SFXindex);
    }
}
