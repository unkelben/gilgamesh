using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject playSpace;
    [SerializeField] Flowchart flowchart;
    [SerializeField] GameObject goblet;
    
    private static int drinkCounter;
    bool startDrinkGame;

    // Update is called once per frame
    void Update()
    {
        startDrinkGame = flowchart.GetBooleanVariable("startDrinkGame");
        drinkCounter = DrinkArea.drinkCounter;

        if (startDrinkGame == true && drinkCounter < 7)
        {
            playSpace.SetActive(true);
        }
        else
        { 
            playSpace.SetActive(false);
        }

        if (drinkCounter == 7 && startDrinkGame == true)
        {
            flowchart.ExecuteBlock("Final Dialogue");
        }
    }
}
