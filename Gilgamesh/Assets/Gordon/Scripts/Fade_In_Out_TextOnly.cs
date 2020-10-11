using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Diagnostics;
using System.Security.Cryptography;
using TMPro;


public class Fade_In_Out_TextOnly : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Transform img;
    [SerializeField] private Transform respawnPoint;

    SpriteRenderer rend;

    public float timeRemaining;
    public bool timerIsRunning = false;

    public MeshRenderer Visble;




    private void Start()
    {
 
        
        Visble.enabled = false;

    }



    public void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.name == "textRespawnPointLeft")
        {
            timerIsRunning = true;
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
                Visble.enabled = true;
                timerIsRunning = false;

            }
        }
    }



}
//Reference:
// https://owlcation.com/stem/How-to-fade-out-a-GameObject-in-Unity