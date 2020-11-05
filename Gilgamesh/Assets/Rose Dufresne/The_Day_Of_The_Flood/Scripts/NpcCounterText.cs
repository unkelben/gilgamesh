using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Rose.Utilities
{
    public class NpcCounterText : MonoBehaviour
    {
        public int counter { get; set; }
        private Text counterText;

        private void Start()
        {
            counter = Int32.Parse(GetComponent<Text>().text);
            counterText = GetComponent<Text>();
        }

        private void Update()
        {
            counterText.text = counter.ToString();
        }
    }
}
