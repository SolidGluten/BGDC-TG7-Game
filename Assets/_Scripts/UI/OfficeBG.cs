using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeBG : MonoBehaviour
{
    public static OfficeBG instance;


    private void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
