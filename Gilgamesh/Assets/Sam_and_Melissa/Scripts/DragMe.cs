// grabbed from:
// https://stackoverflow.com/questions/23152525/drag-object-in-unity-2d
// ...thanks!
//
// Requires a collider. 

using UnityEngine;
using System.Collections;

public class DragMe : MonoBehaviour
{
    // The plane the object is currently being dragged on
    private Plane dragPlane;

    // The difference between where the mouse is on the drag plane and 
    // where the origin of the object is on the drag plane
    private Vector3 offset;

    private Camera myMainCamera;
    GameObject checker;

    Vector3 lastPos;

    float initPushForce = 0.1f;
    float deltaPushForce = 0.01f;
    float pushForce = 0.1f;
    float friction = 6f;
    float dragCounter = 0f;

    float dragStopTime = 0f;
    float dragCheckTime = 0.2f;
    bool dragging = false;

    Vector3 startYZ;
    GameObject granu;

    void Start()
    {
        startYZ = transform.position;   
        myMainCamera = Camera.main; // Camera.main is expensive ; cache it here
        checker = GameObject.Find("PixelCam");
        granu = GameObject.Find("granu");
    }

    private void Update()
    {

        if (dragging && Time.time > dragStopTime)
        {
            dragging = false;
            granu.GetComponent<granulator>().playing = false;
        }

        
        
        
    }

    void OnMouseDown()
    {
        pushForce = initPushForce;

        if (checker.GetComponent<checkPathCovered>().active)
        {
            dragPlane = new Plane(myMainCamera.transform.forward, transform.position);
            Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

            float planeDist;
            dragPlane.Raycast(camRay, out planeDist);
            offset = transform.position - camRay.GetPoint(planeDist);
            lastPos = camRay.GetPoint(planeDist) + offset * pushForce;
            friction = 6f;
            dragCounter = 0;
            dragging = true;
            dragStopTime = Time.time + dragCheckTime;
            granu.GetComponent<granulator>().playing = true;
        }
        
    }

    void OnMouseDrag()
    {
        if (checker.GetComponent<checkPathCovered>().active)
        {
            Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);
       //     pushForce = Mathf.Min(1f, pushForce + offset.x / );
            float planeDist;
            dragPlane.Raycast(camRay, out planeDist);
            friction = Mathf.Max(friction - 0.01f, 2f);

            dragCounter += 0.1f;
            Vector3 newpos = camRay.GetPoint(planeDist) + offset * pushForce;
            
            float x = transform.position.x + (newpos.x - lastPos.x) / friction;
            transform.position = new Vector3(x, startYZ.y + 0.04f*Mathf.Sin(dragCounter)*Mathf.Sin(dragCounter), startYZ.z);

            lastPos = newpos;
            dragging = true;
            dragStopTime = Time.time + dragCheckTime;
            granu.GetComponent<granulator>().playing = true;
        }
            
    }
}