using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    private Vector2 mousePos;
    private Camera mainCam;
    public bool isDrag;
    public bool dragEnabled;
    public Transform lastPos;

    private void Start()
    {
        dragEnabled = true;
        mainCam = Camera.main;
        lastPos = lastPos ? lastPos : transform;
    }

    private void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        if (isDrag && dragEnabled) Drag();
    }

    private void OnMouseDown()
    {
        SetDrag();
    }

    private void OnMouseDrag()
    {
        if(DragNDrop.DragObject != null)
        isDrag = true;
    }

    private void OnMouseUp()
    {
        isDrag = false;
        DragNDrop.DragObject = null;
        ResetPosition();
    }

    public void SetDrag() {
        isDrag = true;
        DragNDrop.DragObject = this.gameObject;
    }

    private void Drag()
    {
        transform.position = mousePos;
    }

    public void ResetPosition()
    {
        transform.position = lastPos.position;
        DragNDrop.DragObject = null;
        isDrag = false;
    }

    public void SetLastPosition(Transform pos)
    {
        lastPos = pos;
        ResetPosition();
    }
}
