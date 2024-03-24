using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionController : MonoBehaviour
{
    public Animator transitionAnim;
    private GraphicRaycaster rayCaster;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        rayCaster = GetComponent<GraphicRaycaster>();
        rayCaster.enabled = false;
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
        rayCaster.enabled = true;
    }

    public void EndTransAnim()
    {
        transitionAnim.SetTrigger("EndTrans");
        rayCaster.enabled = false;
    }
}
