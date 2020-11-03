using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform target;
    [SerializeField] float height; //above target
    [SerializeField] float distance; //behind or in front of target
    [SerializeField] float smoothingSpeed;

    private Vector3 refVelocity;
    private float fixedLookAtRotation;
        
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
        
    void Update()
    {
        HandleCamera();
    }

    protected virtual void HandleCamera()
    {
        if (!target)
        {
            return;
        }

        float mainHeight = 2f * Camera.main.orthographicSize;
        float mainWidth = mainHeight * Camera.main.aspect;

        float height = 2f * this.GetComponent<Camera>().orthographicSize;
        float width = height * this.GetComponent<Camera>().aspect;

        //move camera position to follow target
        float xPosition = 0;
        float yPosition = 0;

        if ((target.position.x - width / 2 <= -mainWidth / 2) || (target.position.x + width / 2 >= mainWidth / 2))
        {
            xPosition = transform.position.x;
        }
        else
        {
            xPosition = target.position.x;
        }
        if ((target.position.y - height/2 <= -mainHeight/2) || (target.position.y + height / 2 >= mainHeight / 2))
        {
            yPosition = transform.position.y;
        }
        else
        {
            yPosition = target.position.y;
        }

        Vector3 targetPosition = new Vector3(xPosition, yPosition, transform.position.z);
        Vector3 finalPosition = targetPosition;


        transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, smoothingSpeed);
        //transform.LookAt(Vector3.forward, target.position);
    }
}
