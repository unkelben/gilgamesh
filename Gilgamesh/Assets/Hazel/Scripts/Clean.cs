using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Clean : MonoBehaviour
{
    public Collider2D bodyCollider;
    public GameObject bubble;
    float elapsedTime = 0;
    public float delay = 0.1f;
    public Sprite[] bubbleSprites;
    public GameObject[] allBubbles;
    public float cleanLvl = 0;
    bool cleaning = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        elapsedTime += Time.deltaTime;
        

        if (Input.GetMouseButton(0) && Random.Range(0,10) == 1 && cleanLvl <= 210)
        {
            if (bodyCollider == Physics2D.OverlapPoint(mousePos))
            {
                elapsedTime = 0;
                cleanLvl += 1;
                Debug.Log(cleanLvl);

                GameObject BubbleInstantiated = Instantiate(bubble, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)))) as GameObject;
                BubbleInstantiated.GetComponent<SpriteRenderer>().sprite = bubbleSprites[Random.Range(0, 3)];
                float r = Random.Range(15, 40);

                BubbleInstantiated.transform.localScale = new Vector3(r, r, 0);
            }

            
        }

        else if (cleanLvl >= 200)
        {
            Debug.Log("ERASE");
            //rain
            Destroy(GameObject.FindWithTag("bubble"));
            cleaning = false;

        }

    }
}
