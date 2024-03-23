using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FishingButton : MonoBehaviour
{
    public BaseIngredient ingredient;
    public Fishing fishing;
    private int SFXindex = 6;
    private void OnMouseDown()
    {
        fishing.Fish(ingredient);
        SoundManager.instance.PlaySoundEffect(SFXindex);
    }
}
