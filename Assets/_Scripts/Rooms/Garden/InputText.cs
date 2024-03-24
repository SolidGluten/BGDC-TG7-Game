using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class InputText : MonoBehaviour
{
    public TextMeshPro textMesh;
    public Garden garden;
    public int SFXIndex = 12;
    private void Start()
    {
        textMesh = GetComponentInChildren<TextMeshPro>();
    }

    public void Input(string inputVal)
    {
        if (string.Compare(inputVal, "DEL") == 0)
        {
            textMesh.text = "";
        }
        else if (string.Compare(inputVal, "ENTER") == 0)
        {
            garden.UnlockPlant(textMesh.text);
            SoundManager.instance.PlaySoundEffect(SFXIndex);
            textMesh.text = "";
        }
        else if (textMesh.text.Length >= 2)
        {
            return;
        }
        else
        {
            textMesh.text = string.Concat(textMesh.text, inputVal);
        }
    }
}
