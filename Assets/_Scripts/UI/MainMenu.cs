using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButtonThing()
    {
        StartCoroutine(GameManager.instance.StartGame(1));
    }
    public void QuitButtonThing()
    {
        Application.Quit();
    }
}