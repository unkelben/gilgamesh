using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverWaterJug : MonoBehaviour
{
    public bool isMouseOverJug = false;

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
        Debug.Log("on jug");

        isMouseOverJug = true;
    }

   void OnMouseExit()
    {
        Debug.Log("not on jug");
        isMouseOverJug = false;
    }
}
