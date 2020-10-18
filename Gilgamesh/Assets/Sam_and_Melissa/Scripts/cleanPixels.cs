using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleanPixels : MonoBehaviour
{
    int brushSize = 7;
    private Camera myMainCamera;
    private Plane dragPlane;
    Renderer rend;
    Texture2D texture;
    bool complete = false;

    List<Vector3> dirt = new List<Vector3>();
    int dirtCount = 100;
    int dirtCleared = 0;

    void Start()
    {

        myMainCamera = Camera.main;
        rend = GetComponent<Renderer>();
        // duplicate the original texture and assign to the material
        texture = Instantiate(rend.material.mainTexture) as Texture2D;
        rend.material.mainTexture = texture;
        /*
        // generate dirt 
        for(int i=0; i<dirtCount; i++)
        {
            int x = Mathf.RoundToInt(Random.Range(0, 128));
            int y = Mathf.RoundToInt(Random.Range(0, 128));
            dirt.Add(new Vector3( x, y,0f) );
            texture.SetPixel(x,y, Color.black);
        }
        // update texture 
        texture.Apply();
        */
    }

    // onmousedown()
    //
    // called when u click on 'canvas'. draws a pixel at mouse position.
    //
    void OnMouseDown()
    {
        cleanAtMousePos(brushSize);
    }


    // onmousedrag()
    //
    // draw on canvas when mouse is moved while pressed 
    //
    void OnMouseDrag()
    {
        cleanAtMousePos(brushSize);
    }

    // drawatmousepos()
    //
    // update pixels on the 'canvas', create paths, add points to them, join them... ya.
    //

    void cleanAtMousePos(int size)
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

        // apply paintbrush stroke at this location:

        // iterate for each pixel in brush
        for (int x = -size; x < maxpix; x++)
        {
            for (int y = -size; y < maxpix; y++)
            {
                // update pixel color:

                if (Random.Range(0, 100) < 20) // including a bit of randomness so cleaning isn't always perfect
                {

                    Color pixColor = texture.GetPixel(pixelX + x, pixelY + y);

                    texture.SetPixel(pixelX + x, pixelY + y, Color.clear);
                    Vector3 pixpos = new Vector3(pixelX + x, pixelY + y, 0f);

                    // if this was a dirty pixel, increment cleaned pixels and 
                    // remove that pixel from dirt array. 
                    if ( pixColor.a != 0f )
                    {
                        dirtCleared++;
                        dirt.Remove(pixpos);
                    }
                }
            }
        }

        // show updated pixels
        texture.Apply();

        if (dirtCleared > 3650)
        {
            complete = true;
            GameObject.Find("scene_manager").GetComponent<sceneManager>().scene3over = true;
            Debug.Log("complete!");
        }
    }
}
