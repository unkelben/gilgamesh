using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverRag : MonoBehaviour
{
    public bool isMouseOverRag = false;
    public bool interactedWithRag = false;
    public bool isWet = false;

    public SpriteRenderer sprite;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        sprite.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactedWithRag == false)
        {
            if (isWet) 
            {
                animator.SetBool("isWet", true);
            }
            
            else
            {
                animator.SetBool("isWet", false);
            }
        }
    }

    void OnMouseEnter()
    {
        Debug.Log("on rag");
        if (interactedWithRag == false)
        {
            sprite.color = Color.gray;
        }
        isMouseOverRag = true;
    }

    void OnMouseExit()
    {
        Debug.Log("not on rag");
        sprite.color = Color.white;
        isMouseOverRag = false;
    }
}
