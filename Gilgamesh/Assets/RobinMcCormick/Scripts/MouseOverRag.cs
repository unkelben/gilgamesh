using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverRag : MonoBehaviour
{
    public bool isMouseOverRag = false;
    public bool interactedWithRag = false;

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
        if (interactedWithRag == false && isMouseOverRag == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Interacted with rag.");
                //     animator.SetBool("isWet", true);
              //  interactedWithRag = true;
            }
            else
            {
                //      animator.SetBool("isWet", false);
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
