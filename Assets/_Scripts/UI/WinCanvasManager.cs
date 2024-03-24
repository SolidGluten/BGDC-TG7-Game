using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinCanvasManager : MonoBehaviour
{
    public static WinCanvasManager Instance;
    public TextMeshProUGUI textMesh;
    public MenuItem ContinueItem;

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
        ContinueItem.gameObject.SetActive(true);
    }

    public void SetWinMessage(string text) {
        textMesh.text = text;
    }

    public void ShowLastWinScreen() {
        this.gameObject.SetActive(true);
        ContinueItem.gameObject.SetActive(false);
    }
}
