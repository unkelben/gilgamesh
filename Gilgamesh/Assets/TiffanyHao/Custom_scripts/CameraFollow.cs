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
    void Update()
    {
        transform.position = new Vector3(player_t.position.x, player_t.position.y, this.transform.position.z); 
        /**
        Vector3 temp = transform.position;

        temp.x = player_t.position.x;
        temp.y = player_t.position.y;

        transform.position = temp; 
         **/ 

    }
}
