using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkArea : MonoBehaviour
{
    [SerializeField] GameObject goblet;
    public bool drinkIsInside;
    public int drinkCounter = 0;
    float initialPosition;
    float velocityY;
    Vector2 gobletPos;


    // Start is called before the first frame update
    void Start()
    {
        gobletPos = new Vector2(goblet.transform.position.x, goblet.transform.position.y);
        initialPosition = gobletPos.y;
        velocityY = -3f;

    }

    // Update is called once per frame
    void Update()
    {
        gobletPos.y = goblet.transform.position.y;
        goblet.GetComponent<Rigidbody2D>().velocity = new Vector2 (0f,velocityY);
        
        if (Input.GetKeyDown(KeyCode.Space) && drinkIsInside == true)
        {
            drinkCounter++;
            velocityY = velocityY - 1;
        } else if (drinkIsInside == false && gobletPos.y < -1f)
        {
            gobletPos.y = initialPosition;
            goblet.transform.position = gobletPos;
        }
        
    }

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
