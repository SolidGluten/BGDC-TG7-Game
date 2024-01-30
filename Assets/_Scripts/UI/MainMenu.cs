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
    public void ResumeButton()
    {
        GameManager.instance.Resume();
    }
    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
