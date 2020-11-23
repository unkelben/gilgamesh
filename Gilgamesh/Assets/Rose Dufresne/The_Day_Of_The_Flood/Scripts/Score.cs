using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Rose.Utilities
{
    public class Score : MonoBehaviour
    {
        public int score { get; set; }

        private Text scoreText;

        public int animalScore { get; set; }
        public int peopleScore { get; set; }

        [SerializeField] bool isPeople;

        void Start()
        {
            scoreText = GetComponent<Text>();

            score = 0;
            animalScore = 0;
            peopleScore = 0;
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
