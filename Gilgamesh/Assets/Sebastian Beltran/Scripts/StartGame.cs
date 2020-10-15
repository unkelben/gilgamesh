using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using CharacterCreator2D;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject playSpace;
    [SerializeField] GameObject exitHouse;
    [SerializeField] Flowchart flowchart;
    [SerializeField] GameObject axe;

    private static int drinkCounter;
    private static int clothesCounter;
    bool startDrinkGame;
    bool startClothesGame = false;

    // Update is called once per frame
    void Update()
    {
        startDrinkGame = flowchart.GetBooleanVariable("startDrinkGame");
        startClothesGame = flowchart.GetBooleanVariable("startClothesGame");
        drinkCounter = DrinkArea.drinkCounter;
        clothesCounter = DrinkArea.clothesCounter;

        if (startDrinkGame == true && drinkCounter < 7)
        {
            playSpace.SetActive(true);
        }
        else if (startClothesGame == true && clothesCounter < 3)
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
            startDrinkGame = false;
        }

        if (clothesCounter == 3)
        {
            flowchart.ExecuteBlock("Need Weapon");
            axe.GetComponent<BoxCollider2D>().enabled = true;
            exitHouse.SetActive(true);
        }
    }
}
