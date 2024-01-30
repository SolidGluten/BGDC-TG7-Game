using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButtonThing()
    {
        StartCoroutine(GameManager.instance.ChangeLevel(0));
    }
    public void QuitButtonThing()
    {
        Application.Quit();
    }
}