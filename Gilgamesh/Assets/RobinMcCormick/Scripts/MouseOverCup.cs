using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverCup : MonoBehaviour
{

    public bool isMouseOverCup = false;
    public bool interactedWithCup = false;
    public MouseOverWaterJug wJ;
    public ChangeBackground cB;

    Animator animator;

    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (wJ.interactedWithJug == true && interactedWithCup == false)
        {
            if (isMouseOverCup == true) { 
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Interacted with cup.");
               // animator.SetBool("cupIsMove", true);
              // cB.interactionAmount = cB.interactionAmount++;
                interactedWithCup = true;
            }
            else
            {
               // animator.SetBool("cupIsMove", false);
            }
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
