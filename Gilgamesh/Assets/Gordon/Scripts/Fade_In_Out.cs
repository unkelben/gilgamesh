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

    [SerializeField] private Transform backgroundEnding;


    public MeshRenderer visbleTextIshullanu;
    public MeshRenderer visbleTextShephered;
    public MeshRenderer visbleTextStallion;
    public MeshRenderer visbleTextTammuz;

    public MeshRenderer visbleTextSorry1;
    public MeshRenderer visbleTextSorry2;
    public MeshRenderer visbleTextSorry3;
    public MeshRenderer visbleTextSorry4;

    public MeshRenderer visbleEnding;
    public MeshRenderer visbleGameOver;



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


    private void Start()
    {
        FadeOutObject();
    }

    void OnMouseDown()
    {
        Debug.Log("Click");
        if(fadeIn == false)
        {
            backgroundEnding.transform.position = respawnPoint.transform.position;
            visbleGameOver.enabled = true;
            FadeOutObject();
        }
        

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
                visbleTextIshullanu.enabled = true;
                visbleTextShephered.enabled = true;
                visbleTextStallion.enabled = true;
                visbleTextTammuz.enabled = true;
               
                visbleTextSorry1.enabled = true;
                visbleTextSorry2.enabled = true;
                visbleTextSorry3.enabled = true;
                visbleTextSorry4.enabled = true;



                visbleEnding.enabled = false;
                fadeIn = false;
            }

        }
    }
  

 
 
}
//Reference:
// https://owlcation.com/stem/How-to-fade-out-a-GameObject-in-Unity