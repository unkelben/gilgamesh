// https://docs.unity3d.com/Manual/class-RenderTexture.html
// https://gamedev.stackexchange.com/questions/129159/unity-read-pixels-of-camera-into-memory

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPathCovered : MonoBehaviour
{

    float nextCheck = 0f;
    float checkInterval = 1f;
    public bool active = true;
    
    float completionThreshold = 0.031f;

    public Texture2D tex;
    private Color32[] pixels;
    private float width, height;
    Color32 pathColor = new Color32(144,127,109,255);
    public RenderTexture renderTexture;
    float totalPix = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (active)
        {
            if (Time.time > nextCheck)
            {
                float counter = 0;
                // next 2 lines grabbed from https://docs.unity3d.com/ScriptReference/Texture2D.ReadPixels.html
               // Texture2D tex = (Texture2D) GetComponent<Renderer>().material.mainTexture;



                Texture2D tex2d = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false);
                totalPix = renderTexture.width * renderTexture.height;
                RenderTexture.active = renderTexture;
                tex2d.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
                tex2d.Apply();


                pixels = tex2d.GetPixels32();
              

                foreach( Color pixel in pixels)
                {
                    if (pixel == pathColor)
                    {
                        counter += 1f;
                    }
                }
                nextCheck = Time.time + checkInterval;
                float percent = counter / totalPix;
                //Debug.Log(percent);

                if (percent > completionThreshold)
                {
                    active = false;
                    Debug.Log("complete!");
                }
            }
        }
        
    }
}
