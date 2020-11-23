using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Rose.Utilities
{
    public class TotalScore : MonoBehaviour
    {
        private Text scoreText;

        void Start()
        {
            scoreText = GetComponent<Text>();
        }
        
        void Update()
        {
            scoreText.text = "Saved: " + Score.score.ToString();
        }
    }
}
