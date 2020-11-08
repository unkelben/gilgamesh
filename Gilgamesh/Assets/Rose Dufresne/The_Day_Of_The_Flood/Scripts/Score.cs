using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Rose.Utilities
{
    public class Score : MonoBehaviour
    {
        public int score { get; set; }

        private Text scoreText;

        void Start()
        {
            scoreText = GetComponent<Text>();

            score = 0;
        }
        
        void Update()
        {
            scoreText.text = "Saved: " + score.ToString();
        }
    }
}
