using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    private Vector2 mousePos;
    private Camera mainCam;
    public DragNDrop dragAndDrop;
    public bool isDrag;
    private Vector2 lastPos;

    private void Start()
    {
        mainCam = Camera.main;
        lastPos = transform.position;
        dragAndDrop = FindAnyObjectByType<DragNDrop>();
    }

    private void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        if (isDrag) Drag();
    }

    private void OnMouseDrag()
    {
        isDrag = true;
        dragAndDrop.DragObject = this.gameObject;
    }

    private void OnMouseUp()
    {
        isDrag = false;
        dragAndDrop.DragObject = null;
        transform.position = lastPos;
    }

    private void Drag()
    {
        transform.position = mousePos;
    }

    public void ResetPosition()
    {
        transform.position = lastPos;
    }

    public void SetLastPosition(Vector2 pos)
    {
        lastPos = pos;
    }
}
