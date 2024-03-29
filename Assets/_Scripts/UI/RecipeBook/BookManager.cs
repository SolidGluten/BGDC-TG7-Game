using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    public static BookManager instance;
    private void Awake()
    {
        // Singleton pattern to ensure only one instance of SoundManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (GameManager.currentState == GameState.PopupOpen)
        {
            this.gameObject.SetActive(false);
            return;
        }
        GameManager.currentState = GameState.PopupOpen;
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        GameManager.currentState = GameState.Playing;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            gameObject.SetActive(false);
        }
    }
}
