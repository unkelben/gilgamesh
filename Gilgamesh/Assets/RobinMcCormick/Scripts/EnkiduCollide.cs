using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnkiduCollide : MonoBehaviour { 

    public MouseOverRag mouseOverRag;
    public MouseOverCup mouseOverCup;
    public ChangeBackground cB;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cup"))
        {
            

            mouseOverCup.animator.enabled = true;
            mouseOverCup.isDrink = true;
            mouseOverCup.cupSource.Play();
            cB.interactionAmount = cB.interactionAmount += 1;
            // animation of cup pouring to enkidu's mouth
            // sfx of drinking enkidu
            // return cup
            // change bg function
            // disable cup function
        }
        else
        {
         //   mouseOverCup.animator.SetBool("isDrink", false);
        }

        if (other.gameObject.CompareTag("Rag"))
        {
            Debug.Log("Rag touched Enkidu");
           if (mouseOverRag.ragOnEnkidu == true)
            {
                mouseOverRag.wipeEnkiduFace = true;
                source.Play();
                // animation of rag gently rubbing over enkidu's face
                // sfx of rag gently rubbing over enkidu's face
                // return rag
                // change bg function
                // disable rag function
            }

        }
    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Rag"))
        {
            other.transform.rotation = Quaternion.Euler(0, 0, -30);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cup"))
        {

               mouseOverCup.interactedWithCup = true;
        }

        if (other.gameObject.CompareTag("Rag"))
        {
            cB.interactionAmount = cB.interactionAmount+=1;
        }
    }
}
