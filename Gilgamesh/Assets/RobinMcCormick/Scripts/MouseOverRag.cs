using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverRag : MonoBehaviour
{
    public bool isMouseOverRag = false;

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
        
    }

    void OnMouseEnter()
    {
        Debug.Log("on rag");
        sprite.color = Color.gray;
        isMouseOverRag = true;
    }

    void OnMouseExit()
    {
        Debug.Log("not on rag");
        sprite.color = Color.white;
        isMouseOverRag = false;
    }
}
