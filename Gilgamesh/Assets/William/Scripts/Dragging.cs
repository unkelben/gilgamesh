using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragging : MonoBehaviour
{

    public bool isDragging;
    Vector2 mousePosition;

   

    public void OnMouseDown()
    {
        isDragging = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition) - transform.position;
 
        if (isDragging)
        {
            //Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }


}

