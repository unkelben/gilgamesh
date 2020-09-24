using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class DragDrop : MonoBehaviour
{

    [SerializeField] private Transform Heart;
    [SerializeField] private Transform respawnPoint;

    [SerializeField] private Transform Ishullanu;
    [SerializeField] private Transform Shephered;
    [SerializeField] private Transform Stallion;
    [SerializeField] private Transform Tammuz;
    [SerializeField] private Transform placeImageOnScreen;

    [SerializeField] private Transform MadIstar;


    private bool isDragging;


    public void OnMouseDown()
    {
        isDragging = true;
       
    }

    public void OnMouseUp()
    {
        isDragging = false;

        if (!GetComponent<Renderer>().isVisible)
        {
            MadIstar.transform.position = placeImageOnScreen.transform.position;
        }

    }

    public void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Heart_Detector")
        {

            if (!isDragging)
            {
                Debug.Log("Yeeee");
                Heart.transform.position = respawnPoint.transform.position;

                int ranInt = Random.Range(1, 5);
       


                if (ranInt == 1) 
                {
                    Debug.Log("1");
                    Ishullanu.transform.position = placeImageOnScreen.transform.position;
                }
                if (ranInt == 2)
                {
                    Debug.Log("2");
                    Shephered.transform.position = placeImageOnScreen.transform.position;
                }
                if (ranInt == 3)
                {
                    Debug.Log("3");
                    Stallion.transform.position = placeImageOnScreen.transform.position;
                }
                if (ranInt == 4)
                {
                    Debug.Log("4");
                    Tammuz.transform.position = placeImageOnScreen.transform.position;
                }
                if (ranInt == 5)
                {
                    Debug.Log("5");
                }

            }
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