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
    public bool moveOn = false;
    int thoughtsIndex = 0;

    public int polesLeft = 24;
    public string animState = "none";

    string[] Alphabet = new string[26] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

    public List<GameObject> thoughts = new List<GameObject>();

    GameObject focusedLetter;
    GameObject focusedLetter2;

    int poleThreshold = 23;
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

        for(int i=0; i<thoughts.Count; i++)
        {
            thoughts[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (state == "game1")
        {

            if (counter == 60)
            {
              instru1.SetActive(true);
             //   GameObject.Find("pressSpace").GetComponent<UnityEngine.UI.Text>().text = "Try moving left and right";
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
              //  GameObject.Find("pressSpace").GetComponent<UnityEngine.UI.Text>().text = "Press Space";
                nextInstru = true;
                instru1.SetActive(false);
             //   instru2.SetActive(true);
              //  shuffleControl(1);
                
            }

            if( nextInstru
                && gilgamesh1.GetComponent<poleGilgameshController>().spacePressed 
               // && !lastSpacePressed
                )
            {
              // Debug.Log(polesLeft);
                if (polesLeft == poleThreshold && !nextInstru2)
                {
                    instru1.SetActive(false);
                  //  instru2.SetActive(false);
                  //  instru2b.SetActive(true);
                //    shuffleControl(2);
                    nextInstru2 = true;
                    nextInstru3 = false;
                }
                
               
                if (
                    polesLeft == poleThreshold 
                    && GameObject.Find("gilga2").GetComponent<poleGilgameshAnimations>().animState=="stillNoPole" 
                    && !nextInstru3
                    )
                {
                  //  instru3.SetActive(false);
                    // reset 
                  //  if (polesLeft > 0) instru2.SetActive(true);

                

                    
                    nextInstru3 = true;
                    nextInstru2 = false;
                    //shuffleControl(1);
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
                
                GameObject.Find("BGM").GetComponent<bgmHandler>().SetSynthVol(1f);
                GameObject.Find("BGM").GetComponent<bgmHandler>().SetGuitVol(1f);
                GameObject.Find("BGM").GetComponent<bgmHandler>().SetDrumVol(1f);
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

      //  Debug.Log("ove on "+moveOn);
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

    public void keepPushing()
    {
     //   instru2b.SetActive(false);
     //   instru3.SetActive(true);
       // shuffleControl(3);

    }

    public void shuffleControl(int whichone)
    {
        string letter = Alphabet[Mathf.FloorToInt(Random.Range(0, 26))];
        gilgamesh1.GetComponent<poleGilgameshController>().ready = true;
        gilgamesh1.GetComponent<poleGilgameshController>().controlKey = letter;

        if (whichone == 1) instru2.GetComponent<UnityEngine.UI.Text>().text = "Press " + letter;// + " to grab a pole";
        else if (whichone == 2) instru2b.GetComponent<UnityEngine.UI.Text>().text = "Press " + letter;// + " again to place it";
        else if (whichone == 3) instru3.GetComponent<UnityEngine.UI.Text>().text = "Mash " + letter;// + " to thrust the boat forward";
    }
    
    public void grabPole() 
    {
        if(polesLeft>0) polesLeft--;
    }

    public void startNextTextAnimation()
    {
        animateText(thoughts[thoughtsIndex]);
        thoughtsIndex = Mathf.Min(thoughtsIndex + 1, thoughts.Count);
    }

    public void letGoPole()
    {
        if (polesLeft == 0)
        {
            // no more poles

            if (state=="game1")
            {
                
                state = "headToFront";
               // moveOn = true;
                // instru3.SetActive(false);
                // headToFront.SetActive(true);
                gilgamesh1.GetComponent<poleGilgameshController>().instructionText = instru2b;
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
       // Debug.Log("Started Coroutine at timestamp : " + Time.time);

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
       // Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
