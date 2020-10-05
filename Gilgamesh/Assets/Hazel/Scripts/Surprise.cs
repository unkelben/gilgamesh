using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surprise : MonoBehaviour
{
    public Sprite surprise;
    public Sprite noSurprise;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            this.GetComponent<SpriteRenderer>().sprite = noSurprise;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        this.GetComponent<SpriteRenderer>().sprite = surprise;

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        this.GetComponent<SpriteRenderer>().sprite = noSurprise;

    }


}
