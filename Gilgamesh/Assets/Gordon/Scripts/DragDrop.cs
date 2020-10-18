using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
//using UnityEditorInternal;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;
using UnityEngine.Audio;

public class DragDrop : MonoBehaviour
{

    [SerializeField] private Transform Heart;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Transform respawnPoint2;

    [SerializeField] private Transform Ishullanu;
    [SerializeField] private Transform Shephered;
    [SerializeField] private Transform Stallion;
    [SerializeField] private Transform Tammuz;
    [SerializeField] private Transform placeImageOnScreen;

    [SerializeField] private Transform Istar;
    [SerializeField] private Transform Istar2;
    [SerializeField] private Transform Istar3;
    [SerializeField] private Transform Istar4;
    [SerializeField] private Transform Istar5;
    [SerializeField] private Transform Istar6;
    [SerializeField] private Transform Istar7;
    [SerializeField] private Transform Istar8;

    [SerializeField] private Transform Gilgamesh;

    [SerializeField] private Transform MadIstar;
    [SerializeField] private Transform VeryMadIstar;
    [SerializeField] private Transform EndingBG;

    

    [SerializeField] private Transform textStart;
    [SerializeField] private Transform textReject;
    [SerializeField] private Transform textSuperReject;

    [SerializeField] private Transform textIshullanu;
    [SerializeField] private Transform textShephered;
    [SerializeField] private Transform textStallion;
    [SerializeField] private Transform textTammuz;

    [SerializeField] private Transform textSorry1;
    [SerializeField] private Transform textSorry2;
    [SerializeField] private Transform textSorry3;
    [SerializeField] private Transform textSorry4;

    

    [SerializeField] private Transform textspawnPointL;
    [SerializeField] private Transform textspawnPointR;


    public MeshRenderer visbleTextIshullanu;
    public MeshRenderer visbleTextShephered;
    public MeshRenderer visbleTextStallion;
    public MeshRenderer visbleTextTammuz;

    public MeshRenderer visbleTextSorry1;
    public MeshRenderer visbleTextSorry2;
    public MeshRenderer visbleTextSorry3;
    public MeshRenderer visbleTextSorry4;


    public AudioSource audioIshullanuKick;
    public AudioSource audioIshullanuFalling;
    public AudioSource audioShepheredDogo;
    public AudioSource audioStallionDrink;
    public AudioSource audioStallionHaha;
    public AudioSource audioStallionWipe;
    public AudioSource audioTammuzWingsRips;
    public AudioSource audioTammuzHaha;
    public AudioSource audioMadIstar;
    public AudioSource audioVeryMadIstar;
    public AudioSource audioBMG;




    private bool isDragging;

    bool seenIshullanu = false;
    bool seenShephered = false;
    bool seenStallion = false;
    bool seenTammuz = false;
    bool allIsSeen = false;

    bool CurrentIshullanu = false;
    bool CurrentShephered = false;
    bool CurrentStallion = false;
    bool CurrentTammuz = false;

    bool isSecretEndAchived = false;

    int currentIllustration;
    int lastIllustration;

    int heartsGiven = 0;


    public void updateWhatHasBeenSeen()
    {
        if (seenIshullanu == true && seenShephered == true && seenStallion == true && seenTammuz == true)
        {
            allIsSeen = true;
        }
        else
        {
            allIsSeen = false;
        }
    }


    public void updateText()
    {
        textStart.transform.position = respawnPoint2.transform.position;
        textIshullanu.transform.position = respawnPoint2.transform.position;
        textShephered.transform.position = respawnPoint2.transform.position;
        textStallion.transform.position = respawnPoint2.transform.position;
        textTammuz.transform.position = respawnPoint2.transform.position;
        textSorry1.transform.position = respawnPoint2.transform.position;
        textSorry2.transform.position = respawnPoint2.transform.position;
        textSorry3.transform.position = respawnPoint2.transform.position;
        textSorry4.transform.position = respawnPoint2.transform.position;

        visbleTextIshullanu.enabled = false;
        visbleTextShephered.enabled = false;
        visbleTextStallion.enabled = false;
        visbleTextTammuz.enabled = false;

        visbleTextSorry1.enabled = false;
        visbleTextSorry2.enabled = false;
        visbleTextSorry3.enabled = false;
        visbleTextSorry4.enabled = false;

        if (CurrentIshullanu == true)
        {
            textIshullanu.transform.position = textspawnPointL.transform.position;
            CurrentIshullanu = false;
        }
        if (CurrentShephered == true)
        {
            textShephered.transform.position = textspawnPointL.transform.position;

            CurrentShephered = false;
        }
        if (CurrentStallion == true)
        {
            textStallion.transform.position = textspawnPointL.transform.position;
            CurrentStallion = false;
        }
        if (CurrentTammuz == true)
        {
            textTammuz.transform.position = textspawnPointL.transform.position;
            CurrentTammuz = false;
        }

        int ranInt = Random.Range(1, 5);

        if (ranInt == 1)
        {
            textSorry1.transform.position = textspawnPointR.transform.position;

        }
        if (ranInt == 2)
        {
            textSorry2.transform.position = textspawnPointR.transform.position;


        }
        if (ranInt == 3)
        {

            textSorry3.transform.position = textspawnPointR.transform.position;


        }
        if (ranInt == 4)
        {
            textSorry4.transform.position = textspawnPointR.transform.position;
        }
        if (ranInt == 5)
        {
            Debug.Log("oh no");
        }

    }

    public void updateTextEnding()
    {
        textStart.transform.position = respawnPoint2.transform.position;
        textIshullanu.transform.position = respawnPoint2.transform.position;
        textShephered.transform.position = respawnPoint2.transform.position;
        textStallion.transform.position = respawnPoint2.transform.position;
        textTammuz.transform.position = respawnPoint2.transform.position;
        textSorry1.transform.position = respawnPoint2.transform.position;
        textSorry2.transform.position = respawnPoint2.transform.position;
        textSorry3.transform.position = respawnPoint2.transform.position;
        textSorry4.transform.position = respawnPoint2.transform.position;

    }

    public void OnMouseDown()
    {
        isDragging = true;

    }

    public void OnMouseUp()
    {
        isDragging = false;


        if (!GetComponent<Renderer>().isVisible)
        {

            updateTextEnding();
            updateWhatHasBeenSeen();
            if (allIsSeen == true && isSecretEndAchived == false)
            {
                Istar.transform.position = respawnPoint2.transform.position;
                Istar2.transform.position = respawnPoint2.transform.position;
                Istar3.transform.position = respawnPoint2.transform.position;
                Istar4.transform.position = respawnPoint2.transform.position;
                Istar5.transform.position = respawnPoint2.transform.position;
                Istar6.transform.position = respawnPoint2.transform.position;
                Istar7.transform.position = respawnPoint2.transform.position;
                Istar8.transform.position = respawnPoint2.transform.position;
                EndingBG.transform.position = placeImageOnScreen.transform.position;
                VeryMadIstar.transform.position = placeImageOnScreen.transform.position;
                audioVeryMadIstar.Play(1);
                audioBMG.Play(0);
                textSuperReject.transform.position = textspawnPointL.transform.position;
                

            }
            
            if(allIsSeen == false && isSecretEndAchived == false)
            {
                Istar.transform.position = respawnPoint2.transform.position;
                Istar2.transform.position = respawnPoint2.transform.position;
                Istar3.transform.position = respawnPoint2.transform.position;
                Istar4.transform.position = respawnPoint2.transform.position;
                Istar5.transform.position = respawnPoint2.transform.position;
                Istar6.transform.position = respawnPoint2.transform.position;
                Istar7.transform.position = respawnPoint2.transform.position;
                Istar8.transform.position = respawnPoint2.transform.position;
                MadIstar.transform.position = placeImageOnScreen.transform.position;
                audioMadIstar.Play(1);
                textReject.transform.position = textspawnPointL.transform.position;
               
            }

        }

    }

    public void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Heart_Detector")
        {

            if (!isDragging)
            {
                Debug.Log("Yeeee");

                HeartGiven();

              
            }
        }

    }

    public void HeartGiven()
    {
        


        if (heartsGiven <= 99)
        {
            
            isSecretEndAchived = false;
            
        }
        if (heartsGiven == 100)
        {
            isSecretEndAchived = true;
         
        }

        if (isSecretEndAchived == false)
        {
            Heart.transform.position = respawnPoint.transform.position;
            pickIllustration();
        }
        if (isSecretEndAchived == true)
        {
            Heart.transform.position = respawnPoint2.transform.position;
            Istar8.transform.position = respawnPoint2.transform.position;
            Gilgamesh.transform.position = placeImageOnScreen.transform.position;
        }


    }




    public void pickIllustration()
    {
        int ranInt = Random.Range(1, 5);
        currentIllustration = ranInt;


        if (currentIllustration == lastIllustration)
        {
            pickIllustration();
        }

        if (currentIllustration != lastIllustration)
        {
            if (currentIllustration == 1)
            {
                Debug.Log("1");
                seenIshullanu = true;
                Ishullanu.transform.position = placeImageOnScreen.transform.position;
                heartsGiven++;
                audioIshullanuKick.Play(1);
                audioIshullanuFalling.Play(1);
                CurrentIshullanu = true;
                updateText();
               
                lastIllustration = currentIllustration;
               

            }
            if (currentIllustration == 2)
            {
                Debug.Log("2");
                seenShephered = true;
                Shephered.transform.position = placeImageOnScreen.transform.position;
                heartsGiven++;
                audioShepheredDogo.Play(1);
                CurrentShephered = true;
                updateText();
                
                lastIllustration = currentIllustration;

            }
            if (currentIllustration == 3)
            {
                Debug.Log("3");
                seenStallion = true;
                Stallion.transform.position = placeImageOnScreen.transform.position;
                heartsGiven++;
                audioStallionDrink.Play(1);
                audioStallionHaha.Play(1);
                audioStallionWipe.Play(1);

                CurrentStallion = true;
                updateText();
                
                lastIllustration = currentIllustration;

            }
            if (currentIllustration == 4)
            {
                Debug.Log("4");
                seenTammuz = true;
                Tammuz.transform.position = placeImageOnScreen.transform.position;
                heartsGiven++;
                audioTammuzWingsRips.Play(1);
                audioTammuzHaha.Play(1);

                CurrentTammuz = true;
                updateText();
                
                lastIllustration = currentIllustration;
            }

            Debug.Log(heartsGiven);
            IstarState();
        }
    }

    public void IstarState() {

        if (heartsGiven == 4){
            Istar.transform.position = respawnPoint2.transform.position;
            Istar2.transform.position = placeImageOnScreen.transform.position;
        }
        if (heartsGiven == 10)
        {
            Istar2.transform.position = respawnPoint2.transform.position;
            Istar3.transform.position = placeImageOnScreen.transform.position;
        }
        if (heartsGiven == 20)
        {
            Istar3.transform.position = respawnPoint2.transform.position;
            Istar4.transform.position = placeImageOnScreen.transform.position;
        }

        //49
        if (heartsGiven == 40)
        {
            Istar4.transform.position = respawnPoint2.transform.position;
            Istar5.transform.position = placeImageOnScreen.transform.position;
        }



        if (heartsGiven == 60)
        {
            Istar5.transform.position = respawnPoint2.transform.position;
            Istar6.transform.position = placeImageOnScreen.transform.position;
        }


      
        if (heartsGiven == 80)
        {
            Istar6.transform.position = respawnPoint2.transform.position;
            Istar7.transform.position = placeImageOnScreen.transform.position;
        }


        //50 99
        if (heartsGiven == 90)
        {
            Istar7.transform.position = respawnPoint2.transform.position;
            Istar8.transform.position = placeImageOnScreen.transform.position;
        }



    }


    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }

        


    }
}
//References:
// https://oxmond.com/how-to-drag-and-drop-a-2d-object/
// https://www.youtube.com/watch?v=55TBhlOt_U8&t=15s&ab_channel=OXMONDTutorials
// https://stackoverflow.com/questions/54505849/check-if-the-object-is-off-screen