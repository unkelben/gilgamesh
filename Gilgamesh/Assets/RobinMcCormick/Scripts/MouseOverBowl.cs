using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverBowl : MonoBehaviour
{
    public bool isMouseOverBowl = false;

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
        Debug.Log("on bowl");
        sprite.color = Color.gray;
        isMouseOverBowl = true;
    }

    void OnMouseExit()
    {
        Debug.Log("not on bowl");
        sprite.color = Color.white;
        isMouseOverBowl = false;
    }
}
