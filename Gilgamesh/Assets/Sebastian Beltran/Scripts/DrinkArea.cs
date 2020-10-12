using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DrinkArea : MonoBehaviour
{
    //Pass Goblet
    [SerializeField] GameObject goblet;
    [SerializeField] GameObject clothes;
    [SerializeField] Flowchart flowchart;

    [SerializeField] Sprite pants;
    [SerializeField] Sprite shoes;


    //Declare boolean that checks if the goblet is inside the drink area
    //Initialize the count of drinks to 0
    //Declare variable to store initial goblet position
    //Declare velocity for goblet
    //Declare vector 2 for goblet position
    public bool drinkIsInside;
    bool startClothesGame;
    public static int drinkCounter = 0;
    public static int clothesCounter = 0;
    float initialPosition;
    float initialPosClothes;
    float velocityX = 0f;
    float velocityY;
    Vector2 gobletPos;
    Vector2 clothesPos;


    // Start
    //initialize goblet position, velocity value and store Y position
    void Start()
    {
        gobletPos = new Vector2(goblet.transform.position.x, goblet.transform.position.y);
        clothesPos = new Vector2(clothes.transform.position.x, clothes.transform.position.y);
        initialPosition = gobletPos.y;
        initialPosClothes = clothesPos.y;
        velocityY = -3f;

        clothes.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        startClothesGame = flowchart.GetBooleanVariable("startClothesGame");

        drinkGame();

        if (startClothesGame == true)
        {
            clothesGame();
        }

    }

    public void clothesGame()
    {
        clothes.SetActive(true);
        velocityY = -3f;
        clothesPos.y = clothes.transform.position.y;
        clothes.GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);

        if (Input.GetKeyDown(KeyCode.Space) && drinkIsInside == true)
        {
            clothesCounter++;
            clothesPos.y = initialPosClothes;
            clothes.transform.position = clothesPos;
            if (clothesCounter == 1)
            {
                clothes.GetComponent<SpriteRenderer>().sprite = pants;
            }
            else if (clothesCounter == 2)
            {
                clothes.GetComponent<SpriteRenderer>().sprite = shoes;
            }
        }
        else if (drinkIsInside == false && clothesPos.y < -1f)
        {
            clothesPos.y = initialPosClothes;
            clothes.transform.position = clothesPos;
        }

    }

    public void drinkGame()
    {
        //update goblet position with current position
        gobletPos.y = goblet.transform.position.y;

        //pass velocity values to game object
        goblet.GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);

        //if space is hit when the goblet is inside the drink area then add 1 to the counter and increase velocity
        //else reset position
        if (Input.GetKeyDown(KeyCode.Space) && drinkIsInside == true)
        {
            drinkCounter++;
            velocityY = velocityY - 1.5f;
        }
        else if (drinkIsInside == false && gobletPos.y < -1f)
        {
            gobletPos.y = initialPosition;
            goblet.transform.position = gobletPos;
        }

        if (drinkCounter == 7)
        {
            goblet.SetActive(false);
        }
    }

    //OnTrigger events check wether the goblet is inside of the drink area or not
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            drinkIsInside = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            drinkIsInside = false;
        }
    }


}
