using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    public Animator transitionAnim;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
        LevelManager.OnLevelChanging += StartTransAnim;
        GameManager.OnBackToMenu += StartTransAnim;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        LevelManager.OnLevelChanging -= StartTransAnim;
        GameManager.OnBackToMenu -= StartTransAnim;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        EndTransAnim();
    }

    public void StartTransAnim()
    {
        transitionAnim.SetTrigger("StartTrans");
    }

    public void EndTransAnim()
    {
        transitionAnim.SetTrigger("EndTrans");
    }
}
