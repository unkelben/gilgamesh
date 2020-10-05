using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverBowl : MonoBehaviour
{
    public bool isMouseOverBowl = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        Debug.Log("on bowl");

        isMouseOverBowl = true;
    }

    void OnMouseExit()
    {
        Debug.Log("not on bowl");
        isMouseOverBowl = false;
    }
}
