using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleHandler : MonoBehaviour
{
    public bool hovered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        hovered = true;
    }

    private void OnMouseExit()
    {
        hovered = false;
    }
}
