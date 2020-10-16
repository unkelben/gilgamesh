using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Clean : MonoBehaviour
{
    public Collider2D bodyCollider;
    public GameObject bubble;
    public Sprite[] bubbleSprites;
    public GameObject enkiDirty;
    public GameObject[] allBubbles;
    public float cleanLvl = 0;
    public bool cleaning = true;
    public float rinsing = 0;
    public GameObject rain;
    // Start is called before the first frame update
    void Start()
    {
        if (cleanLvl <= 155) { 
            rain.GetComponent<Renderer>().enabled = false;

    }
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        


        if (Input.GetMouseButton(0) && Random.Range(0, 10) == 1 && cleanLvl <= 155)
        {
            if (bodyCollider == Physics2D.OverlapPoint(mousePos))
            {
                
                cleanLvl += 1;

                GameObject BubbleInstantiated = Instantiate(bubble, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)))) as GameObject;
                BubbleInstantiated.GetComponent<SpriteRenderer>().sprite = bubbleSprites[Random.Range(0, 3)];
                float r = Random.Range(15, 45);

                BubbleInstantiated.transform.localScale = new Vector3(r, r, 0);
            }


        }

        else if (cleanLvl >= 150)
        {

            //rain
           rain.GetComponent<Renderer>().enabled = true;
            enkiDirty.GetComponent<Renderer>().enabled = false;
            Destroy(GameObject.FindWithTag("bubble"));
            rinsing += 1;

            if (rinsing >= 500){
                cleaning = false;
                
                rain.GetComponent<Renderer>().enabled = false;
            }

            
            

        }

    }
}
