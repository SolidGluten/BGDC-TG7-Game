using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SendButton : InputButton
{
    private int SFXindex = 0;
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        SoundManager.instance.PlaySoundEffect(SFXindex);
    }
}
