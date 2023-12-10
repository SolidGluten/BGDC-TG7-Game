using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRaw : MonoBehaviour
{
    bool canMove;
    bool Drag;
    new Collider2D collider;
    [SerializeField] private GameObject Raw;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        canMove = true;
        Drag = true;
    }

    void Update()
    {
        DragNDrop();
    }
    // Update is called once per frame
    private void DragNDrop()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (collider == Physics2D.OverlapPoint(mousePos))
            {
                canMove = true;
            }
            else
            {
                canMove = false;
            }
            if (canMove)
            {
                Drag = true;
            }

        }
        if (Drag)
        {
            this.transform.position = mousePos;
        }
        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
            Drag = false;
            Destroy(Raw);
        }
    }
}
