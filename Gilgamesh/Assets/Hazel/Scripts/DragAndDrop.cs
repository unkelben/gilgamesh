﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragAndDrop : MonoBehaviour
{
    bool canMove;
    bool dragging;
    public Collider2D clothesCollider;
    public Collider2D bodyCollider;
    public Sprite off;
    void Start()
    {
        canMove = false;
        dragging = false;

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
        }

        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
            dragging = false;
            this.GetComponent<SpriteRenderer>().sprite = off;
        }
    }

}
