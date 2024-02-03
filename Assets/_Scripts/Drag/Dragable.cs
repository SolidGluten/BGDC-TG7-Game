using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    private Vector2 mousePos;
    private Camera mainCam;
    public bool isDrag;
    public Transform lastPos;

    private void Start()
    {
        mainCam = Camera.main;
        lastPos = lastPos ? lastPos : transform;
    }

    private void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        if (isDrag) Drag();
    }

    private void OnMouseDown()
    {
        DragNDrop.DragObject = this.gameObject;
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
    }
}
