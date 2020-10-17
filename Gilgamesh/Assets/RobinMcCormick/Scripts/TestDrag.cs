using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDrag : MonoBehaviour
{
    private bool isDragging;
    public bool dragActive;

    public MouseOverCup overCup;
    public MouseOverRag overRag;

    public Collider2D cupCollider;
    public Collider2D ragCollider;
    public Collider2D enkiduCollider;

    public void OnMouseDown()
    {
        isDragging = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            if (dragActive)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                transform.Translate(mousePosition);
                CheckDragColl();
            }
        }
    }

    public void CheckDragColl()
    {
        if (cupCollider == enkiduCollider)
        {
            Debug.Log("Cup has touched Enkidu!");
        }

        if (ragCollider == enkiduCollider)
        {
            Debug.Log("Rag has touched Enkidu!");
        }
    }
}
