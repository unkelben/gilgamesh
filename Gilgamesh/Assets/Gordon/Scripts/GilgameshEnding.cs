using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Diagnostics;
using System.Security.Cryptography;
using System.ComponentModel.Design;

public class GilgameshEnding : MonoBehaviour
{

    [SerializeField] private Transform placeImageOnScreen;

    [SerializeField] private Transform EndingImage;

    public MeshRenderer visbleGameOver;

    public AudioSource GilgameshSpeaks;

    SpriteRenderer rend;
    private bool fadeOut = false;
    private bool fadeIn = false;
    public float fadeSpeed;

    private bool Gamestart = true;

    public float timeRemaining;
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
                visbleGameOver.enabled = true;
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
                   
                   

                    //UnityEditor.EditorApplication.isPlaying = false;
                    //Application.Quit();

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
                GilgameshSpeaks.Play(1);
                timerIsRunning = true;
                EndingImage.transform.position = placeImageOnScreen.transform.position;

                
                fadeIn = false;

            }

        }
    }




}
//Reference:
// https://owlcation.com/stem/How-to-fade-out-a-GameObject-in-Unity
// https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/