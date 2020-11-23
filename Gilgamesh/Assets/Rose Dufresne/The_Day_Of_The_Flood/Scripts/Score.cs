using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Rose.Utilities
{
    public class Score : MonoBehaviour
    {
        public static int score;

        private Text scoreText;

        public static int animalScore;
        public static int peopleScore;

        [SerializeField] bool isPeople;

        void Start()
        {
            scoreText = GetComponent<Text>();
        }
        
        void Update()
        {
            score = peopleScore + animalScore;
            
            if (isPeople)
            {
                scoreText.text = "People: " + peopleScore.ToString();
            }
               
            else
                scoreText.text = "Animals: " + animalScore.ToString();
        }
    }
}
