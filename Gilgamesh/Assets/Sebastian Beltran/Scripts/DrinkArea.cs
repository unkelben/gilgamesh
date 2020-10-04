using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkArea : MonoBehaviour
{
    //Pass Goblet
    [SerializeField] GameObject goblet;
    

    //Declare boolean that checks if the goblet is inside the drink area
    //Initialize the count of drinks to 0
    //Declare variable to store initial goblet position
    //Declare velocity for goblet
    //Declare vector 2 for goblet position
    public bool drinkIsInside;
    public static int drinkCounter = 0;
    float initialPosition;
    float velocityX = 0f;
    float velocityY;
    Vector2 gobletPos;


    // Start
    //initialize goblet position, velocity value and store Y position
    void Start()
    {
        gobletPos = new Vector2(goblet.transform.position.x, goblet.transform.position.y);
        initialPosition = gobletPos.y;
        velocityY = -3f;

    }

    // Update is called once per frame
    void Update()
    {
        //update goblet position with current position
        gobletPos.y = goblet.transform.position.y;

        //pass velocity values to game object
        goblet.GetComponent<Rigidbody2D>().velocity = new Vector2 (velocityX,velocityY);

        //if space is hit when the goblet is inside the drink area then add 1 to the counter and increase velocity
        //else reset position
        if (Input.GetKeyDown(KeyCode.Space) && drinkIsInside == true)
        {
            drinkCounter++;
            velocityY = velocityY - 1.5f;
        } else if (drinkIsInside == false && gobletPos.y < -1f)
        {
            gobletPos.y = initialPosition;
            goblet.transform.position = gobletPos;
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
