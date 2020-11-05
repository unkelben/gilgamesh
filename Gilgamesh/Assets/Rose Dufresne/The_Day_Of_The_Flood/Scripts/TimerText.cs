using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Rose.Utilities
{
    public class TimerText : MonoBehaviour
    {
        public int timeLeft { get; set; }
        private Text timerText;

        private float timer;

        private void Start()
        {
            timeLeft = (Int32.Parse(GetComponent<Text>().text.Substring(0,1))*60) + Int32.Parse(GetComponent<Text>().text.Substring(2, 2));
            timerText = GetComponent<Text>();

            timer = 0f;
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                timeLeft -= 1;
                string minutes = ((int)timeLeft / 60).ToString();
                int seconds = (timeLeft % 60);
                if (seconds < 10)
                    timerText.text = minutes + ":" + seconds.ToString();
                else
                    timerText.text = minutes + ":" + seconds;
                timer = 0;
            }
        }
    }
}
