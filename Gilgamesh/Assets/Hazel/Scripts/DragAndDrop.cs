using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragAndDrop : MonoBehaviour
{
    bool canMove;
    bool dragging;
    public Collider2D clothesCollider;
    public Collider2D bodyCollider;
    public Sprite off;
    public int originalLayer;
    void Start()
    {
        canMove = false;
        dragging = false;
        originalLayer = this.GetComponent<SpriteRenderer>().sortingOrder;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (clothesCollider == Physics2D.OverlapPoint(mousePos))
            {
                canMove = true;
                this.GetComponent<Snap>().dressed = false;
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
            this.GetComponent<SpriteRenderer>().sprite = off;
            this.transform.position = mousePos;
            this.GetComponent<SpriteRenderer>().sortingOrder = 100;
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
            dragging = false;
            this.GetComponent<SpriteRenderer>().sortingOrder = originalLayer;
        }
    }

}
