using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dressed : MonoBehaviour
{
    public float shirt;
    public float shoes;
    public float dress;
    public float pants;
    public float hair;
    // Start is called before the first frame update
    void Start()
    {
       shirt = 0;
       shoes = 0;
       dress = 0;
       pants = 0;
        hair = 0;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(shirt + " " + shoes + " " + dress + " " + pants + " " + hair);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "shirt")
        {
            shirt += 1;
}
        if (collision.gameObject.tag == "hair")
        {
            hair += 1;
        }

        if (collision.gameObject.tag == "shoes")
        {
            shoes += 1;
        }

        if (collision.gameObject.tag == "pants")
        {
            pants += 1;
        }

        if (collision.gameObject.tag == "dress")
        {
            dress += 1;
        }
 
    }

    void OnCollisionExit2D(Collision2D collision)
{

    if (collision.gameObject.tag == "shirt")
    {
            shirt += -1;
        }

        if (collision.gameObject.tag == "shoes")
        {
            shoes += -1;
        }

        if (collision.gameObject.tag == "pants")
        {
            pants += -1;
        }

        if (collision.gameObject.tag == "dress")
        {
            dress += -1;
        }

        if (collision.gameObject.tag == "hair")
        {
            hair += -1;
        }

    }
}