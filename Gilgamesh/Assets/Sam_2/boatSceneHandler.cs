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

    string state = "game1";

    public int polesLeft = 10;
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
            
            if ( counter == 60 ) instru1.SetActive(true);
       //     if( counter > 180 && gilgamesh2.GetComponent<sailorGilgameshInputs>().upPressed)

            if(
                counter>180
                && gilgamesh1.GetComponent<poleGilgameshController>().leftPressed
                && gilgamesh1.GetComponent<poleGilgameshController>().rightPressed
                && !nextInstru
                )
            {
                
                instru2.SetActive(true);
                nextInstru = true;
            }

            if(nextInstru
                && gilgamesh1.GetComponent<poleGilgameshController>().spacePressed 
                )
            {
                if (polesLeft == 9 && !nextInstru2)
                {
                    instru1.SetActive(false);
                    instru2.SetActive(false);
                    instru2b.SetActive(true);
                    nextInstru2 = true;
                }
                
               
                if (polesLeft == 8 &&!nextInstru3)
                {
                    instru3.SetActive(false);
                    nextInstru3 = true;
                }
            }
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
                headToFront.SetActive(true);
            }
        }
    }
}
