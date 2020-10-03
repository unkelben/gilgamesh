using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //If the object hit is the player
        if (Input.GetMouseButtonUp(0))
        {
            this.transform.position = new Vector3(0, 0, 0);
        }
    }
}
