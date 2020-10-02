using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player_t; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.y = player_t.position.y - 2;
        transform.position = new Vector3(0, temp.y, this.transform.position.z); 
        /**
        Vector3 temp = transform.position;

        temp.x = player_t.position.x;
        temp.y = player_t.position.y;

        transform.position = temp; 
         **/ 

    }
}
