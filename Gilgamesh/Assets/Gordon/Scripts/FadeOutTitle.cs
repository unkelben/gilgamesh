using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Diagnostics;
using System.Security.Cryptography;

public class FadeOutTitle : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Transform img;
    [SerializeField] private Transform respawnPoint;

    [SerializeField] private Transform text;
    [SerializeField] private Transform text2;
    [SerializeField] private Transform text3;

    public MeshRenderer text4;




    private bool fadeOut = false;
    private bool fadeIn = false;
    public float fadeSpeed;



    public void FadeOutObject()
    {
        fadeOut = true;
    }



    private void Start()
    {
        text4.enabled = false;
    }

    void OnMouseDown()
    {
        Debug.Log("Click");
        if (fadeIn == false)
        {
            text.transform.position = respawnPoint.transform.position;
            text2.transform.position = respawnPoint.transform.position;
            text3.transform.position = respawnPoint.transform.position;
            text4.enabled = true;
            FadeOutObject();
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
