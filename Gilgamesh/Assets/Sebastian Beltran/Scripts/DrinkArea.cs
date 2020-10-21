using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCreator2D;
using Fungus;

public class DrinkArea : MonoBehaviour
{
    //Pass Goblet
    [SerializeField] GameObject goblet;
    [SerializeField] GameObject clothes;
    [SerializeField] Flowchart flowchart;
    [SerializeField] CharacterViewer enkidu;

    [SerializeField] Sprite pants;
    [SerializeField] Sprite shoes;
    [SerializeField] Sprite wearArea;

    AudioSource drink;


    //Declare boolean that checks if the goblet is inside the drink area
    //Initialize the count of drinks to 0
    //Declare variable to store initial goblet position
    //Declare velocity for goblet
    //Declare vector 2 for goblet position
    public bool drinkIsInside;
    bool startClothesGame;
    bool startDrinkGame;
    public static int drinkCounter = 0;
    public static int clothesCounter = 0;
    private int flowDrinkCounter = 0;
    float initialPosition;
    float initialPosClothes;
    float velocityX = 0f;
    float velocityY;
    Vector2 gobletPos;
    Vector2 clothesPos;

    public Color shirtColor1;
    public Color shirtColor2;
    public Color pantsColor;
    public Color bootsColor;


    // Start
    //initialize goblet position, velocity value and store Y position
    void Start()
    {
        gobletPos = new Vector2(goblet.transform.position.x, goblet.transform.position.y);
        clothesPos = new Vector2(clothes.transform.position.x, clothes.transform.position.y);
        initialPosition = gobletPos.y;
        initialPosClothes = clothesPos.y;
        velocityY = -3f;

        drink = goblet.GetComponent<AudioSource>();

        clothes.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        startDrinkGame = flowchart.GetBooleanVariable("startDrinkGame");
        startClothesGame = flowchart.GetBooleanVariable("startClothesGame");

        if(startDrinkGame == true)
        {
            drinkGame();
        }

        if (startClothesGame == true)
        {
            clothesGame();
        }

    }

    public void clothesGame()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = wearArea;
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
                enkidu.EquipPart(SlotCategory.Armor, "Fantasy 01 Male");
                enkidu.SetPartColor(SlotCategory.Armor, shirtColor1, shirtColor2, shirtColor2);
                clothes.GetComponent<SpriteRenderer>().sprite = pants;
            }
            else if (clothesCounter == 2)
            {
                flowchart.ExecuteBlock("Hurry");
                enkidu.EquipPart(SlotCategory.Skirt, "");
                enkidu.EquipPart(SlotCategory.Pants, "Fantasy 00 Male");
                enkidu.SetPartColor(SlotCategory.Pants, ColorCode.Color1, pantsColor);
                clothes.GetComponent<SpriteRenderer>().sprite = shoes;
            }
            else if (clothesCounter == 3)
            {
                enkidu.EquipPart(SlotCategory.Boots, "Fantasy 00");
                enkidu.SetPartColor(SlotCategory.Boots, ColorCode.Color1, bootsColor);
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
            velocityY = velocityY - 2f;
            drink.Play(0);
        }
        else if (drinkIsInside == false && gobletPos.y < -1f)
        {
            gobletPos.y = initialPosition;
            goblet.transform.position = gobletPos;
        }

        if (drinkCounter == 1)
        {
            flowchart.ExecuteBlock("First Drink");
        }
        else if (drinkCounter == 2)
        {
            flowchart.ExecuteBlock("Two Drinks");
        }
        else if (drinkCounter == 3)
        {
            flowchart.ExecuteBlock("Three Drinks");
        }
        else if (drinkCounter == 4)
        {
            flowchart.ExecuteBlock("Four Drinks");
        }
        else if (drinkCounter == 5)
        {
            flowchart.ExecuteBlock("Five Drinks");
        }
        else if (drinkCounter == 6)
        {
            flowchart.ExecuteBlock("Six Drinks");
        }
        else if (drinkCounter == 7)
        {
            flowchart.ExecuteBlock("Seven Drinks");
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
