using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinCanvasManager : MonoBehaviour
{
    public static WinCanvasManager Instance;
    public TextMeshProUGUI textMesh;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        this.gameObject.SetActive(false);
    }

    public void SetWinScreen(bool val) {
        this.gameObject.SetActive(val);
    }

    public void SetWinMessage(string text) {
        textMesh.text = text;
    }
}
