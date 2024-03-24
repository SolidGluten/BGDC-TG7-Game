using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FishingButton : InputButton
{
    public BaseIngredient ingredient;
    public Fishing fishing;
    private int SFXindex = 6;

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        fishing.Fish(ingredient);
        SoundManager.instance.PlaySoundEffect(SFXindex);
    }
}
