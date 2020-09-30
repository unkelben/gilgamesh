using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Diagnostics;
using System.Security.Cryptography;
using System.ComponentModel.Design;

public class Fade_In_and_Quit : MonoBehaviour
{
    // Start is called before the first frame update

    SpriteRenderer rend;
    private bool fadeOut = false;
    private bool fadeIn = false;
    public float fadeSpeed;

    private bool Gamestart = true;

    public float timeRemaining = 2;
    public bool timerIsRunning = false;


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


 

    public void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Heart_Detector" && fadeIn == false)
        {
            FadeInObject();
        }
    }


    void FixedUpdate()
    {

        if (timerIsRunning == true)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                FadeOutObject();
                timerIsRunning = false;

            }
        }

        if (fadeOut == true)
        {

            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor;

            if (objectColor.a <= 0)
            {
               
                fadeOut = false;

                if (Gamestart == false)
                {
                    Debug.Log("Close Game");
                    UnityEditor.EditorApplication.isPlaying = false;
                    Application.Quit();
                }

            }
        }

        if (fadeIn == true)
        {
            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor;

            if (objectColor.a >= 1)
            {
                Gamestart = false;
                timerIsRunning = true;
                fadeIn = false;
               
            }

        }
    }




}
//Reference:
// https://owlcation.com/stem/How-to-fade-out-a-GameObject-in-Unity
// https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/