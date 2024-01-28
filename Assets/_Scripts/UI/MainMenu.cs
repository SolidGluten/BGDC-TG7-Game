using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButtonThing()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitButtonThing()
    {
        Application.Quit();
    }
}