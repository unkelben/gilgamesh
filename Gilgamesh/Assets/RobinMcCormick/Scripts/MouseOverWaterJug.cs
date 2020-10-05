using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverWaterJug : MonoBehaviour
{
    public bool isMouseOverJug = false;
    bool interactedWithJug = false;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactedWithJug == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Interacted with jug.");
                animator.SetBool("isPour", true);
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

        isMouseOverJug = true;
    }

   void OnMouseExit()
    {
        Debug.Log("not on jug");
        isMouseOverJug = false;
    }
}
