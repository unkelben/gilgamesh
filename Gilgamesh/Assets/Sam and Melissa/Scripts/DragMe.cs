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

    void Start()
    {
        myMainCamera = Camera.main; // Camera.main is expensive ; cache it here
        checker = GameObject.Find("PixelCam");
    }

    void OnMouseDown()
    {
        if (checker.GetComponent<checkPathCovered>().active)
        {
            dragPlane = new Plane(myMainCamera.transform.forward, transform.position);
            Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

            float planeDist;
            dragPlane.Raycast(camRay, out planeDist);
            offset = transform.position - camRay.GetPoint(planeDist);
        }
        
    }

    void OnMouseDrag()
    {
        if (checker.GetComponent<checkPathCovered>().active)
        {
            Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

            float planeDist;
            dragPlane.Raycast(camRay, out planeDist);
            Vector3 newpos = camRay.GetPoint(planeDist) + offset;
            transform.position = new Vector3(newpos.x, transform.position.y, transform.position.z);
        }
            
    }
}