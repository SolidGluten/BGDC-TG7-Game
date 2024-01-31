using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_BackToMenu : MenuItem
{
    public override void OnSelect()
    {
        SceneManager.LoadScene(0);
    }
}
