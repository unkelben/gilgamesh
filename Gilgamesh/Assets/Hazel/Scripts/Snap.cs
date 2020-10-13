using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{
    public Vector3 location;
    public Vector3 location2;
    public Sprite on;
    public GameObject[] hairs;
    // Start is called before the first frame update
    void Start()
    {   

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetMouseButtonUp(0))
        {

            if (GameObject.Find("enkiBase").GetComponent<Dressed>().hair >= 2)
            {

                hairs = GameObject.FindGameObjectsWithTag("hair");

                foreach (GameObject hair in hairs)
                {
                    hair.transform.position = location2;
                }


            }
        }

        this.transform.position = location;
        this.GetComponent<SpriteRenderer>().sprite = on;
    }



}
