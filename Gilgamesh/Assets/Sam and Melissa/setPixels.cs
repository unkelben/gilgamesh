// Used this as a starting point: https://docs.unity3d.com/ScriptReference/Texture2D.SetPixels.html

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class setPixels : MonoBehaviour
{
    private Camera myMainCamera;
    private Plane dragPlane;
    Renderer rend;
    Texture2D texture;
    List<List<Vector3>> paths = new List<List<Vector3>>();

    void Start()
    {

        myMainCamera = Camera.main;
        rend = GetComponent<Renderer>();
        // duplicate the original texture and assign to the material
        texture = Instantiate(rend.material.mainTexture) as Texture2D;
        rend.material.mainTexture = texture;

    }

    void OnMouseDown()
    {
        drawAtMousePos(1);
    }

    void OnMouseDrag()
    {
        drawAtMousePos(1);
    }

    void drawAtMousePos(int size)
    {
        size--;
        dragPlane = new Plane(myMainCamera.transform.forward, transform.position);
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

        float planeDist;
        dragPlane.Raycast(camRay, out planeDist);

        Vector3 sceneXY = camRay.GetPoint(planeDist);
        Vector3 localXY = sceneXY - (rend.bounds.center - rend.bounds.extents);

        
        int pixelX = Mathf.FloorToInt(128f * localXY.x / (rend.bounds.extents.x * 2f));
        int pixelY = Mathf.FloorToInt(128f * localXY.y / (rend.bounds.extents.y * 2f));

        int maxpix = size + 1;

        for (int x = -size; x < maxpix; x++)
        {
            for (int y = -size; y < maxpix; y++)
            {
                // update pixel color 
                if (x == 0 && y == 0)
                {
                    texture.SetPixel(pixelX, pixelY, Color.black);
                }
                else if(Random.Range(0, 100) < 20)
                {
                    texture.SetPixel(pixelX + x, pixelY + y, Color.gray);
                }

                // update paths content
                bool added = false;

                Vector3 pix = new Vector3(pixelX + x, pixelY + y, 0);
                List<int> joining = new List<int>();
                int counter = 0;

                foreach (List<Vector3> path in paths)
                {   
                    foreach (Vector3 vec in path)
                    {
                        Vector3 d = pix - vec;
                        if(d.magnitude < 3f)
                        {
                            // pixel is close enough to something in this list 
                            added = true;
                            
                        }
                    }

                    if(added)
                    {
                        path.Add(pix);
                        joining.Add(counter);
                    }

                    counter++;
                }

                // if pixel was close to multiple paths, join paths
                if (joining.Count > 1)
                {
                    foreach( int index in joining)
                    {
                        if (index != joining[0])
                        {
                            foreach (Vector3 point in paths[index])
                            {
                                paths[joining[0]].Add(point);
                            }

                            paths.Remove( paths[index] );
                        }
                        
                    }

                    Debug.Log("joined!");
                }

                if (!added)
                {
                    List<Vector3> newpath = new List<Vector3>();
                    newpath.Add(pix);
                    paths.Add(newpath);
                    Debug.Log("new");
                }
            }
        }

        
        texture.Apply();
    }

}