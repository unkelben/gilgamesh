using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rippleEffect : MonoBehaviour
{
    // code based on this Coding Train video: 
    // https://www.youtube.com/watch?v=BZUdGqeOD0w

    private Camera myMainCamera;
    private Plane dragPlane;
    Renderer rend;
    Texture2D texture;

    public List<Transform> interactingObjects;


    public float brushval = 100f;
    float damping = 0.999f;
    int cols;
    int rows;
    float[,] current;
    float[,] previous;
    float startval = 0;
    int counter = 0;

    public float outMin = 0f;
    public float outMax = 255f;

    public int travelRate = 2;
    int travelAmount = 3;
    int pixelSurvivalChance = 80;

    // Start is called before the first frame update
    void Start()
    {

        rend = GetComponent<Renderer>();
        Texture tex = rend.material.mainTexture;
        texture = Instantiate(tex) as Texture2D;
        rend.material.mainTexture = texture;
        cols = tex.width;
        rows = tex.height;
        previous = new float[cols, rows];
        current = new float[cols, rows];
        myMainCamera = Camera.main;
        

        for (int i = 1; i < cols - 1; i++)
        {
            for (int j = 1; j < rows - 1; j++)
            {
                current[i, j] = startval;
                previous[i, j] = startval;
            }
        }

        previous[68, 68] = brushval;

        dragPlane = new Plane(myMainCamera.transform.forward, transform.position);
    }

    // Update is called once per frame
    void Update()
    {

        switch (travelRate)
        {
            case 1: damping = 0.99999999f; pixelSurvivalChance = 10; break;
            case 2: damping = 0.999999f; pixelSurvivalChance = 20; break;
            case 3: damping = 0.9991f; pixelSurvivalChance = 88;  break;
            case 4: damping = 0.998f; pixelSurvivalChance = 80; break;
            case 5: damping = 0.994f; pixelSurvivalChance = 80; break;
            case 6: damping = 0.994f; pixelSurvivalChance = 80; break;
            case 8: damping = 0.994f; pixelSurvivalChance = 80; break;
        }
       // Debug.Log("yo");
        for(int i=1; i<cols-1; i++)
        {
            for(int j=1; j<rows-1; j++)
            {
                current[i, j] = 
                    ( previous[i - 1, j] 
                    + previous[i + 1, j] 
                    + previous[i, j - 1] 
                    + previous[i, j + 1] ) / 2 - current[i, j];
                current[i, j] = (current[i, j] * damping);
                
                byte grey =(byte)( outMin+(outMax-outMin)*( 255f - current[i, j] )/255f );
                texture.SetPixel(i, j, new Color32(grey,grey,grey , 255 ));
            }
        }

        // show updated pixels
        texture.Apply();

        float[,] temp = new float[cols, rows];
        temp = previous;
        previous = current;
        current = temp;

        counter++;

        if (counter % travelRate == 0)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < travelAmount; j++)
                {
                    if (Random.Range(0, 100) > pixelSurvivalChance)
                    {
                        previous[rows - 1 - j, i] = previous[travelAmount - 1 - j, i];
                        current[rows - 1 - j, i] = current[travelAmount - 1 - j, i];
                    }
                    else
                    {
                        previous[rows - 1 - j, i] = startval;
                        current[rows - 1 - j, i] = startval;
                    }
                        
                }

            }
        

        for (int i=0; i<cols- travelAmount; i++)
            {
                for(int j=0; j<rows; j++)
                {
                    if (Random.Range(0, 100) < 60)
                    {
                        current[i, j] = current[i + travelAmount, j];
                        previous[i, j] = previous[i + travelAmount, j];

                    }
                    else
                    {
                        current[i, j] = startval;
                        previous[i, j] = startval;
                    }
                        
                }
            }

        }

        if (counter % 10 == 0)
        {
            int pixelX = Random.Range(cols-100, cols-10);
            int pixelY = Random.Range(10, rows-10);
            previous[pixelX, pixelY] = brushval;
        }

        drawAtObjectsPos();

    }

    void OnMouseDrag()
    {
        drawAtMousePos();
    }

    void drawAtMousePos()
    {
        // next 4 lines are taken from that stackoverflow issue on top of the doc
        
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);
        float planeDist;
        dragPlane.Raycast(camRay, out planeDist);
        // the result is the scene coordinates of my mouse click 
        Vector3 sceneXY = camRay.GetPoint(planeDist);

        // mouse position relative to canvas top-left corner 
        Vector3 localXY = sceneXY - (rend.bounds.center - rend.bounds.extents);

        // map to pixel in texture image
        int pixelX = Mathf.FloorToInt(cols * localXY.x / (rend.bounds.extents.x * 2f));
        int pixelY = Mathf.FloorToInt(rows * localXY.y / (rend.bounds.extents.y * 2f));

        previous[pixelX, pixelY] = brushval;

    }

    void drawAtObjectsPos()
    {
        foreach(Transform obj in interactingObjects)
        {
            if (obj.gameObject.active)
            {
                Vector3 screenPos = myMainCamera.WorldToScreenPoint(obj.position);
             //   Debug.Log(screenPos);
                Ray objRay = myMainCamera.ScreenPointToRay(screenPos);
                float planeDist;
                dragPlane.Raycast(objRay, out planeDist);
                // the result is the scene coordinates of my mouse click 
                Vector3 sceneXY = objRay.GetPoint(planeDist);

                // mouse position relative to canvas top-left corner 
                Vector3 localXY = sceneXY - (rend.bounds.center - rend.bounds.extents);

                // map to pixel in texture image
                int pixelX = Mathf.FloorToInt(cols * localXY.x / (rend.bounds.extents.x * 2f));
                int pixelY = Mathf.FloorToInt(rows * localXY.y / (rend.bounds.extents.y * 2f));

                previous[pixelX, pixelY] = brushval;
            }
     
        }
    }
}
