using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Button : MonoBehaviour
{
    public SceneController SceneController;

    [SerializeField] private Rooms RoomTo;

    public void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
           StartCoroutine(SceneController.ChangeScene((int)RoomTo));
        }
    }

}
