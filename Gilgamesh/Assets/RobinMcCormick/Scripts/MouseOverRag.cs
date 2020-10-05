using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverRag : MonoBehaviour
{
    public bool isMouseOverRag = false;
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
        Debug.Log("on rag");

        isMouseOverRag = true;
    }

    void OnMouseExit()
    {
        Debug.Log("not on rag");
        isMouseOverRag = false;
    }
}
