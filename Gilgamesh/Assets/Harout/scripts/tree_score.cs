using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tree_score : MonoBehaviour
{
    public static int scoreValue ;

    public GameObject humbaba;

    Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        scoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = scoreValue.ToString();


        if (scoreValue >= 30)
        {
            humbaba.SetActive(true);
        }

    }
}
