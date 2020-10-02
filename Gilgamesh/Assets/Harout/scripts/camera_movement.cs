using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{


    public Transform target;
    public float smoothing;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position != target.position)
        { 
            Vector3 targetPosition = new Vector3(target.position.x,
                                                target.position.y,
                                                transform.position.z);

            transform.position = Vector3.Lerp(transform.position,
                                              targetPosition, smoothing);
        }
    }
}
