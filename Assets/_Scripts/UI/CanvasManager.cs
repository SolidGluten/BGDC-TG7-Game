using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject canvas;
    private void Start()
    {
        //This just sets the Canvas object to true everytime you play
        //For the most part this script does nothing other than that...
        canvas.SetActive(true);
    }
}
