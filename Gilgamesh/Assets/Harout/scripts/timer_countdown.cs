using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer_countdown : MonoBehaviour
{






    float currentTime = 0f;
    float startingTime = 30f;

    [SerializeField] Text countdownText;

     void Start()
    {

        currentTime = startingTime;

    }


    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 20)
        {
            SceneManager.LoadScene("game_over");
        }


     //   if (currentTime <= 0)
     //   {
    //        currentTime = 0;
//              }

    }




}
