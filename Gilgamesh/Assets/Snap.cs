using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   

    }

    void OnCollisionStay2D(Collision2D collision)
    {

        this.transform.position = new Vector3(53, 0, 0);
        
    }
}
