using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject playSpace;
    
    private static int drinkCounter;

    // Update is called once per frame
    void Update()
    {

        drinkCounter = DrinkArea.drinkCounter;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            playSpace.SetActive(true);
        }

        if (drinkCounter == 7)
        {
            playSpace.SetActive(false);
        }
    }
}
