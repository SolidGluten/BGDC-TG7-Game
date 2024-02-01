using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_BackToMenu : MenuItem
{
    public override void OnSelect()
    {
        StartCoroutine(GameManager.instance.BackToMenu());
    }
}
