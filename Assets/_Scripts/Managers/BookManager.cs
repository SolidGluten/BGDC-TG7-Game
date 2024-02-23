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
    }
}
