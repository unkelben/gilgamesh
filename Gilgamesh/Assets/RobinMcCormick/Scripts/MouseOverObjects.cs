using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverObjects : MonoBehaviour
{
    public bool isMouseOver = false;

    Ray ray;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            print(hit.collider.name);
        }
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
