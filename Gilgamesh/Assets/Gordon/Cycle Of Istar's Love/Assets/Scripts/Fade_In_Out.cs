using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Diagnostics;
using System.Security.Cryptography;

public class Fade_In_Out : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Transform img;
    [SerializeField] private Transform respawnPoint;

    SpriteRenderer rend;
    private bool fadeOut = false;
    private bool fadeIn = false;
    public float fadeSpeed;

 

    public void FadeOutObject()
    {
        fadeOut = true;
    }

    public void FadeInObject()
    {
        fadeIn = true;
    }


    void OnMouseDown()
    {
        Debug.Log("Click");

        FadeOutObject();

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "Heart_Detector" && fadeIn == false)
        {
            FadeInObject();
        }
    }


    void FixedUpdate()
    {
        
        if (fadeOut == true)
        {

            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor;

            if (objectColor.a <= 0)
            {
                img.transform.position = respawnPoint.transform.position;
                fadeOut = false;

            }
        }

        if (fadeIn == true)
        {
            Debug.Log("HFHFHFH");
            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor;

            if (objectColor.a >= 1)
            {
                fadeIn = false;
            }

        }
    }
  

 
 
}
//Reference:
// https://owlcation.com/stem/How-to-fade-out-a-GameObject-in-Unity