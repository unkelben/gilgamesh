// Used this as a starting point: https://docs.unity3d.com/ScriptReference/Texture2D.SetPixels.html
// As well as parts of this: https://stackoverflow.com/questions/23152525/drag-object-in-unity-2d
// thanks yall.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class setPixels : MonoBehaviour
{

    public int brushSize = 2;
    private Camera myMainCamera;
    private Plane dragPlane;
    Renderer rend;
    Texture2D texture;
    List<List<Vector3>> paths = new List<List<Vector3>>();
    Vector3 pointA = new Vector3(40f, 50f, 0f);
    Vector3 pointB = new Vector3(40f, 78f, 0f);
    bool connected = false;

    GameObject startPoint;
    GameObject endPoint;
    GameObject sceneManager;
    void Start()
    {
        sceneManager = GameObject.Find("scene_manager");
        myMainCamera = Camera.main;
        rend = GetComponent<Renderer>();
        // duplicate the original texture and assign to the material
        texture = Instantiate(rend.material.mainTexture) as Texture2D;
        rend.material.mainTexture = texture;

        // add points A and B to paths list 
        List<Vector3> newpath = new List<Vector3>();
        newpath.Add(pointA);
        paths.Add(newpath);

        newpath = new List<Vector3>();
        newpath.Add(pointB);
        paths.Add(newpath);

        float fact = rend.bounds.size.x / 128f;
        // show points A and B:
        startPoint = GameObject.Find("startPoint");
        endPoint = GameObject.Find("stopPoint");
        startPoint.transform.position = new Vector3(
            transform.position.x - rend.bounds.size.x / 2 + fact * pointA.x,
            transform.position.y - rend.bounds.size.y / 2 + fact * pointA.y,
            startPoint.transform.position.z);

        endPoint.transform.position = new Vector3(
            transform.position.x - rend.bounds.size.x / 2 + fact * pointB.x,
            transform.position.y - rend.bounds.size.y / 2 + fact * pointB.y,
            endPoint.transform.position.z);
        /*
        texture.SetPixel(Mathf.RoundToInt(pointA.x), Mathf.RoundToInt(pointA.y), Color.blue);
        texture.SetPixel(Mathf.RoundToInt(pointB.x), Mathf.RoundToInt(pointB.y), Color.blue);
        texture.Apply();
        */
    }

    private void Update()
    {
        if (connected)
        {
            sceneManager.GetComponent<sceneManager>().scene2over = true;
        }
    }

    // onmousedown()
    //
    // called when u click on 'canvas'. draws a pixel at mouse position.
    //
    void OnMouseDown()
    {
        Debug.Log("mouse down");
        drawAtMousePos(brushSize);
    }

    // onmouseup()
    //
    // when user lets go of mouse, check if point A and point B are connected 
    // (they are connected if they are both in the same path), then color that path.
    // 

    void OnMouseUp()
    {
        if (!connected)
        {
            foreach (List<Vector3> path in paths)
            {
                if (path.Contains(pointA) && path.Contains(pointB))
                {
                    if (!connected)
                    {
                        foreach (Vector3 vec in path)
                        {
                            texture.SetPixel(Mathf.RoundToInt(vec.x), Mathf.RoundToInt(vec.y), Color.green);
                        }
                        texture.Apply();
                    }
                    
                    connected = true;
                } 
            }
        }
        
    }

    // onmousedrag()
    //
    // draw on canvas when mouse is moved while pressed 
    //
    void OnMouseDrag()
    {
        drawAtMousePos(brushSize);
    }

    // drawatmousepos()
    //
    // update pixels on the 'canvas', create paths, add points to them, join them... ya.
    //

    void drawAtMousePos(int size)
    {
        // next 4 lines are taken from that stackoverflow issue on top of the doc
        dragPlane = new Plane(myMainCamera.transform.forward, transform.position);
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);
        float planeDist;
        dragPlane.Raycast(camRay, out planeDist);
        // the result is the scene coordinates of my mouse click 
        Vector3 sceneXY = camRay.GetPoint(planeDist);
        
        // mouse position relative to canvas top-left corner 
        Vector3 localXY = sceneXY - (rend.bounds.center - rend.bounds.extents);

        // map to pixel in texture image
        int pixelX = Mathf.FloorToInt(128f * localXY.x / (rend.bounds.extents.x * 2f));
        int pixelY = Mathf.FloorToInt(128f * localXY.y / (rend.bounds.extents.y * 2f));

        int maxpix = size;
        size--;

        // add paintbrush stroke at this location:

        // iterate for each pixel in brush
        for (int x = -size; x < maxpix; x++)
        {
            for (int y = -size; y < maxpix; y++)
            {
                // update pixel color:

                // pixel on the line is black
                if (x == 0 && y == 0)
                {
                    texture.SetPixel(pixelX, pixelY, Color.black);
                }
                // pixels around are gray
                else if(Random.Range(0, 100) < 20)
                {
                    texture.SetPixel(pixelX + x, pixelY + y, Color.gray);
                }

                // add pixels to paths list:

                bool added = false;
                Vector3 pix = new Vector3(pixelX + x, pixelY + y, 0);
                List<int> joining = new List<int>();
                int counter = 0;

                // check if we should add pixel to an existing path:
                foreach (List<Vector3> path in paths)
                {
                    bool inrange = false;
                    foreach (Vector3 vec in path)
                    {
                        Vector3 d = pix - vec;
                        // pixel is close enough to something in this list 
                        if (d.magnitude < 3f)
                        {
                            added = true;
                            inrange = true;
                        }
                    }

                    // if pixel is in range of any of this path's pixels
                    if(inrange)
                    {
                        // add pixel to path 
                        path.Add(pix);
                        // remember this path's index so that later we can check if any paths overlap at this point
                        joining.Add(counter);
                    }

                    counter++;
                }

                // if pixel matched with more than 1 path, 
                // then we should join those paths together to form one.
                if (joining.Count > 1)
                {
                    foreach( int index in joining)
                    {
                        if (index != joining[0])
                        {
                            // add points to first path
                            foreach (Vector3 point in paths[index])
                            {
                                paths[joining[0]].Add(point);
                            }
                            // remove old path
                            paths.Remove( paths[index] );
                        }
                    }
                    //Debug.Log("joined! path count: " + paths.Count);
                }

                // finally, if pixel didn't match any existing path, 
                // then create a new path and add pixel to that.
                if (!added)
                {
                    List<Vector3> newpath = new List<Vector3>();
                    newpath.Add(pix);
                    paths.Add(newpath);
                    //Debug.Log("new path. new count: "+paths.Count);
                }
            }
        }

        // show updated pixels
        texture.Apply();
    }

}