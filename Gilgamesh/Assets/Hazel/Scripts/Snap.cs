using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{
    public Vector3 location;
    public Vector3 locationBack;
    public Sprite on;
    public Sprite off;
    public bool dressed = false;
    private AudioSource source;
    public GameObject[] hairs;
    public GameObject[] shoes;
    public GameObject[] shirts;
    public GameObject[] dresses;
    public GameObject[] pants;
    public GameObject bubble;
    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 5.0f;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        locationBack = this.transform.position;

        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (bubble.GetComponent<Clean>().cleaning == true)
        {
            this.GetComponent<Renderer>().enabled = false;
            bubble.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        }

        else
        {
            this.GetComponent<Renderer>().enabled = true;
            float t = (Time.time - startTime) / duration;
            bubble.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, t));
        }
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        
        this.transform.position = location;
        this.GetComponent<SpriteRenderer>().sprite = on;
        dressed = true;

        if (!Input.GetMouseButton(0))
        {

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
                        if (hair.GetComponent<Snap>().dressed == true)
                        {
                            hair.transform.position = hair.GetComponent<Snap>().locationBack;
                            this.GetComponent<SpriteRenderer>().sprite = off;
                        }
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
                        if (shirt.GetComponent<Snap>().dressed == true)
                        {
                            shirt.transform.position = shirt.GetComponent<Snap>().locationBack;
                            this.GetComponent<SpriteRenderer>().sprite = off;
                        }
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
                        if (shoe.GetComponent<Snap>().dressed == true)
                        {
                            shoe.transform.position = shoe.GetComponent<Snap>().locationBack;
                            this.GetComponent<SpriteRenderer>().sprite = off;
                        }
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
                        if (dresse.GetComponent<Snap>().dressed == true)
                        {
                            dresse.transform.position = dresse.GetComponent<Snap>().locationBack;
                            this.GetComponent<SpriteRenderer>().sprite = off;
                        }
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
                        if (pant.GetComponent<Snap>().dressed == true)
                        {
                            pant.transform.position = pant.GetComponent<Snap>().locationBack;
                            this.GetComponent<SpriteRenderer>().sprite = off;
                        }
                    }
                }
            }

        
    }

    }

}
