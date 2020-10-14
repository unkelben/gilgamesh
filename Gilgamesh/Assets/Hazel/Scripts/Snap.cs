using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{
    public Vector3 location;
    public Vector3 locationBack;
    public Sprite on;
    public Sprite off;
    public GameObject[] hairs;
    public GameObject[] shoes;
    public GameObject[] shirts;
    public GameObject[] dresses;
    public GameObject[] pants;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        this.transform.position = location;
        this.GetComponent<SpriteRenderer>().sprite = on;

        if (!Input.GetMouseButton(0))
        {

            Debug.Log("1");
            hairs = GameObject.FindGameObjectsWithTag("hair");
            shoes = GameObject.FindGameObjectsWithTag("shoes");
            shirts = GameObject.FindGameObjectsWithTag("shirt");
            dresses = GameObject.FindGameObjectsWithTag("dress");
            pants = GameObject.FindGameObjectsWithTag("pants");


            if (GameObject.Find("enkiBase").GetComponent<Dressed>().hair >= 2)
            {
                foreach (GameObject hair in hairs)
                {
                    if (this.name == hair.name)
                    {

                    }
                    else
                    {
                        hair.transform.position = locationBack;
                        this.GetComponent<SpriteRenderer>().sprite = off;
                    }
                }
            }
            if (GameObject.Find("enkiBase").GetComponent<Dressed>().shirt >= 2)
            {
                foreach (GameObject shirt in shirts)
                {
                    if (this.name == shirt.name)
                    {

                    }
                    else
                    {
                        shirt.transform.position = locationBack;
                        this.GetComponent<SpriteRenderer>().sprite = off;
                    }
                }
            }
            if (GameObject.Find("enkiBase").GetComponent<Dressed>().shoes >= 2)
            {
                foreach (GameObject shoe in shoes)
                {
                    if (this.name == shoe.name)
                    {

                    }
                    else
                    {
                        shoe.transform.position = locationBack;
                        this.GetComponent<SpriteRenderer>().sprite = off;
                    }
                }
            }
            if (GameObject.Find("enkiBase").GetComponent<Dressed>().shirt >= 2 || GameObject.Find("enkiBase").GetComponent<Dressed>().pants >= 2)
            {
                foreach (GameObject dresse in dresses)
                {
                    if (this.name == dresse.name)
                    {

                    }
                    else
                    {
                        dresse.transform.position = locationBack;
                        this.GetComponent<SpriteRenderer>().sprite = off;
                    }
                }
            }
            if (GameObject.Find("enkiBase").GetComponent<Dressed>().pants >= 2)
            {
                foreach (GameObject pant in pants)
                {
                    if (this.name == pant.name)
                    {

                    }
                    else
                    {
                        pant.transform.position = locationBack;
                        this.GetComponent<SpriteRenderer>().sprite = off;
                    }
                }
            }


        }

    }

}
