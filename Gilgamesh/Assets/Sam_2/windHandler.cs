using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windHandler : MonoBehaviour
{
    // not really a reference for this script but it is where i got the line renderer idea
    //https://www.gamasutra.com/blogs/JaneFriedhoff/20180402/316022/Where_C_Meets_CSS_Tech_Tricks_From_An_AR_Lyrics_Experiment.php
    
    public float startval1 = 0f;
    public float startval2 = 50f;
    public float endval1 = 50f;
    public float endval2 = 100f;
    float counter = 0;
    public float animLength = 100;

    public Material mat;
    Material targetmat;
    GameObject gilgamesh;
    GameObject boat;

    public int height = 0;
    public float windPower = 1f;

    // Start is called before the first frame update
    void Start()
    {
        gilgamesh = GameObject.Find("gilga1");
        boat = GameObject.Find("boat");
        targetmat = Instantiate(mat);
        gameObject.GetComponent<LineRenderer>().material = targetmat;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float val1 = Mathf.Lerp(startval1, endval1, counter / animLength);
        float val2 = Mathf.Lerp(startval2, endval2, counter / animLength);

        targetmat.mainTextureOffset = new Vector2(val2, 0);
        targetmat.mainTextureScale= new Vector2(val1, 1.19f);

        if (counter > 0.8 * animLength)
        {
           if( gilgamesh.GetComponent<sailorGilgameshInputs>().height == height)
            {
                boat.GetComponent<boatMotion>().boatPower += windPower;
            }
        }
        counter++;

        if (counter == animLength) Destroy(gameObject);
    }
}
