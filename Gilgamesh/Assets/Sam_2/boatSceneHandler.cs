using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatSceneHandler : MonoBehaviour
{
    public GameObject gilgamesh1;
    public GameObject gilgamesh2;
    public GameObject windMaker;
    public GameObject headToFront;
    public GameObject boat;
    public GameObject instru1;
    public GameObject instru2;
    public GameObject instru2b;
    public GameObject instru3;
    public GameObject instru4;
    public GameObject youReDone;
    bool windMakerSpawned = false;
    int counter = 0;
    bool nextInstru = false;
    bool nextInstru2 = false;
    bool nextInstru3 = false;
    public GameObject letterObject;
    string state = "game1";
    bool lastSpacePressed = false;
    bool moveOn = false;

    public int polesLeft = 10;
    string animState = "none";

    GameObject focusedLetter;
    GameObject focusedLetter2;

    int poleThreshold = 9;
    // Start is called before the first frame update
    void Start()
    {
        gilgamesh2.SetActive(false);
        headToFront.SetActive(false);
        youReDone.SetActive(false);

        instru1.SetActive(false);
        instru2.SetActive(false);
        instru3.SetActive(false);
        instru4.SetActive(false);
        instru2b.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (state == "game1")
        {

            if (counter == 60)
            {
              instru1.SetActive(true);
               // animateText(instru1);

            }
       //     if( counter > 180 && gilgamesh2.GetComponent<sailorGilgameshInputs>().upPressed)

            if(
                counter>180
                && gilgamesh1.GetComponent<poleGilgameshController>().leftPressed
                && gilgamesh1.GetComponent<poleGilgameshController>().rightPressed
                && !nextInstru
               
                )
            {
               
                nextInstru = true;
                instru2.SetActive(true);
                
            }

            if( nextInstru
                && gilgamesh1.GetComponent<poleGilgameshController>().spacePressed 
               // && !lastSpacePressed
                )
            {
                Debug.Log("space!");
                if (polesLeft == poleThreshold && !nextInstru2)
                {
                    instru1.SetActive(false);
                    instru2.SetActive(false);
                    instru2b.SetActive(true);
                    nextInstru2 = true;
                    nextInstru3 = false;
                }
                
               
                if (
                    polesLeft == poleThreshold 
                    && GameObject.Find("gilga2").GetComponent<poleGilgameshAnimations>().animState=="stillNoPole" 
                    && !nextInstru3
                    )
                {
                    instru3.SetActive(false);
                    if(polesLeft>0) instru2.SetActive(true);
                    nextInstru3 = true;
                    nextInstru2 = false;
                    poleThreshold--;
                }
            }
           // lastSpacePressed = gilgamesh1.GetComponent<poleGilgameshController>().spacePressed;
            counter++;
        }
        else if (state == "headToFront")
        {
            if (gilgamesh1.transform.position.x >= 5f)
            {
                counter = 0;
                state = "game2";
                windMakerSpawned = true;
                Instantiate(windMaker);
                gilgamesh1.SetActive(false);
                gilgamesh2.SetActive(true);
                headToFront.SetActive(false);
                instru4.SetActive(true);
            }
        }
        else if (state == "game2")
        {
            counter++;
            if (counter > 400)
            {
                float power = boat.GetComponent<boatMotion>().boatPower;
                Camera.main.orthographicSize += power * 0.00007f;
                instru4.SetActive(false);
            }



            if (Camera.main.orthographicSize > 16f)
            {
                youReDone.SetActive(true);
            }
            
          //  Debug.Log(power);
        }


        if (animState=="enter"&& focusedLetter.GetComponent<RectTransform>().anchoredPosition.x < -140f)
        {
            animState = "click";
        }

        if (animState=="click" && moveOn)
        {
            animState = "leave";
            moveOn = false;
            GameObject[] letters = GameObject.FindGameObjectsWithTag("flyLetter");
            foreach (GameObject letter in letters)
            {
                letter.GetComponent<letterScript>().frozen = false;
            }
        }

        if(animState=="leave" && focusedLetter2 == null)
        {
            animState = "none";
        }
    }
    
    public void grabPole() 
    {
        if(polesLeft>0) polesLeft--;
    }

    public void letGoPole()
    {
        if (polesLeft == 0)
        {
            // no more poles

            if (state=="game1")
            {
                
                state = "headToFront";
                instru3.SetActive(false);
                headToFront.SetActive(true);
            }
        }
    }

    void animateText(GameObject input)
    {
        StartCoroutine(ExampleCoroutine(input));
        
    }

    IEnumerator ExampleCoroutine(GameObject input)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        string txt = input.GetComponent<UnityEngine.UI.Text>().text;
        int startval = 0;
        for (int i = startval; i < txt.Length+ startval; i++)
        {
            GameObject newLetter = Instantiate(letterObject);
            newLetter.GetComponent<UnityEngine.UI.Text>().text = ""+txt[i];
            newLetter.GetComponent<letterScript>().offset = i;
            Vector3 pos = newLetter.GetComponent<RectTransform>().anchoredPosition;
            
            if (i == startval) focusedLetter = newLetter;
            else if (i == txt.Length + startval - 1) focusedLetter2 = newLetter;
         //   letterObject.GetComponent<letterScript>().letter = txt[i];

            yield return new WaitForSeconds(0.108f);
            animState = "enter";
        }
        //yield on a new YieldInstruction that waits for 5 seconds.

        
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
