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
    public Transform lastPos;

    private void Start()
    {
        mainCam = Camera.main;
        lastPos = lastPos ? lastPos : transform;
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
        ResetPosition();
    }

    private void Drag()
    {
        transform.position = mousePos;
    }

    public void ResetPosition()
    {
        transform.position = lastPos.position;
    }

    public void SetLastPosition(Transform pos)
    {
        lastPos = pos;
    }
}
