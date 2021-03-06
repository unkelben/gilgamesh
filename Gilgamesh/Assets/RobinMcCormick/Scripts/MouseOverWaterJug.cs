﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverWaterJug : MonoBehaviour
{
    public bool isMouseOverJug;
    public bool interactedWithJug;

    private AudioSource source;

    Animator animator;

    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        interactedWithJug = false;
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
        sprite.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactedWithJug == false && isMouseOverJug == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Interacted with jug.");
                animator.SetBool("isPour", true);
                source.Play();

                interactedWithJug = true;
            } else
            {
                animator.SetBool("isPour", false);
            }
        }
    }

    void OnMouseEnter()
    {
        Debug.Log("on jug");
        if (interactedWithJug == false)
        {
            sprite.color = Color.gray;
        }
        isMouseOverJug = true;
    }

   void OnMouseExit()
    {
        Debug.Log("not on jug");
        sprite.color = Color.white;
        isMouseOverJug = false;
    }
}
