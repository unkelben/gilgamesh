using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverCup : MonoBehaviour
{

    public bool isMouseOverCup = false;
   // bool interactedWithCup = false;

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
        Debug.Log("on cup");
        sprite.color = Color.gray;
        isMouseOverCup = true;
    }

    void OnMouseExit()
    {
        Debug.Log("not on cup");
        sprite.color = Color.white;
        isMouseOverCup = false;
    }
}
