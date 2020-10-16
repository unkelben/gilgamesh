using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{

    [Header ("Position Variables")]
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;


    [Header("Position Reset")]
    public vector_value camMin;
    public vector_value camMax;
    // Start is called before the first frame update
    void Start()
    {

        maxPosition = camMax.initialValue;
        minPosition = camMin.initialValue;
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position != target.position)
        { 
            Vector3 targetPosition = new Vector3(target.position.x,
                                                target.position.y,
                                                transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x,
                                            minPosition.x,
                                            maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y,
                                            minPosition.y,
                                            maxPosition.y);

            transform.position = Vector3.Lerp(transform.position,
                                              targetPosition, smoothing);
        }
    }
}
