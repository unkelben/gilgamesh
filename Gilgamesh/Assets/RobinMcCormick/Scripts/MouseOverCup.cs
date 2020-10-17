﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverCup : MonoBehaviour
{

    public bool isMouseOverCup = false;
    public bool interactedWithCup = false;
    public MouseOverWaterJug wJ;
    public ChangeBackground cB;

    bool canMove;
    bool dragging;
    public Collider2D cupCollider;
    public Collider2D enkiduCollider;

    // Animator animator;

    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.white;

        canMove = false;
        dragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       // Debug.Log(mousePos);
        if (wJ.interactedWithJug == true)

        //&& isMouseOverCup == true
        {
            //interactedWithCup == false   
            if (Input.GetMouseButtonDown(0))
            {
                
                if (cupCollider == Physics2D.OverlapPoint(mousePos))
                {
                    Debug.Log("Clicked cup");
                    canMove = true;
                    Debug.Log("canMove = true");
                    //   this.GetComponent<Snap>().dressed = false;
                }
                else
                {
                    canMove = false;
                }
                if (canMove)
                {
                    dragging = true;
                    Debug.Log("dragging = true");
                }

                if (dragging)
                {
                   
                    this.transform.position = mousePos;
                    Debug.Log("Transform to mouse pos");

                }

                if (Input.GetMouseButtonUp(0))
                {
                    canMove = false;
                    dragging = false;
                }

                // animator.SetBool("cupIsMove", true);
                 cB.interactionAmount = cB.interactionAmount++;
                //  interactedWithCup = true;
            }

            

        }
    }
        

    void OnMouseEnter()
    {
        Debug.Log("on cup");
        if (interactedWithCup == false)
        {
            sprite.color = Color.gray;
        }
        isMouseOverCup = true;
    }

    void OnMouseExit()
    {
        Debug.Log("not on cup");
        sprite.color = Color.white;
        isMouseOverCup = false;
    }
}
