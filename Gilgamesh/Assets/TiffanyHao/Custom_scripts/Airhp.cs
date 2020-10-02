﻿using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Airhp : MonoBehaviour
{
    public Slider s;

    [SerializeField]
    public static float decreaseRate = 0.0002f; 
    // Start is called before the first frame update
    void Start()
    {
        //set the value of the initial air bar to 1 at the start of the game. 
        s.value = 1; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(s.value <= 0)
        {

            SceneManager.LoadScene("BadEnding"); 
        }

        //if(s.value > 0)
        //{
          //  s.value -= decreaseRate; 
        //}
    }

}