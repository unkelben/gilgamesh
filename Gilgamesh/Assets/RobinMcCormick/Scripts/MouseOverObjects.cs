using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverObjects : MonoBehaviour
{
    public bool isMouseOver = false;

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
        Debug.Log("mouse over!");
        isMouseOver = true;
    }

    void OnMouseExit()
    {
        Debug.Log("mouse gone!");
        isMouseOver = false;
    }
}
