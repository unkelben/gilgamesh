using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DragAndDrop : MonoBehaviour
{
    bool canMove;
    bool dragging;
    public Collider2D collider;
    public Collider2D collider2;
    void Start()
    {
        collider = GetComponent<Collider2D>();
        collider2 = GetComponent<Collider2D>();
        canMove = false;
        dragging = false;

    }

    // Update is called once per frame
    void Update()
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
                dragging = true;
            }


        }
        if (dragging)
        {
            this.transform.position = mousePos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
            dragging = false;
        }
    }

}
