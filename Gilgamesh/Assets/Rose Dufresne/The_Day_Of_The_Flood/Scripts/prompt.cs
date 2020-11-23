using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Rose.Utilities
{
    public class Prompt : MonoBehaviour
    {

        public bool speedUp { get; set; }
        private Text promptText;
        
        // Start is called before the first frame update
        void Start()
        {
            promptText = GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}