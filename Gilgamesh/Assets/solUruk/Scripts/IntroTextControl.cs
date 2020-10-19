using Fungus;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.UI; 

public class IntroTextControl : MonoBehaviour
{
    // Start is called before the first frame update

    public CanvasGroup downbutton;

    //Color downbutton_o; 

    public bool istransparent;


    void Start()
    {
        //downbutton_o = downbutton.GetComponent<Color>(); 
        //downbutton = GetComponent<CanvasGroup>(); 
    }

    // Update is called once per frame

    
    void FixedUpdate()
    {
        if(istransparent)
        {
            //Debug.Log("Fading in"); 
            FadeIn(); 
        }
        else if (!istransparent)
        {
            //Debug.Log("Fading out");
            FadeOut();
        }

        /*
        if(!istransparent)
        {
            Debug.Log("transparentus"); 
            //downbutton_o.a = 0.5f;
            istransparent = true; 

        }
        */

        /*
        if(istransparent)
        {
            Debug.Log("appear"); 
            downbutton_o.a = 1;
            istransparent = false; 
        }
        */
    }
       

    public void FadeIn()
    {
        StartCoroutine(FadeImage(downbutton, downbutton.alpha, 1));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeImage(downbutton, downbutton.alpha, 0));
       
    }

    public IEnumerator FadeImage(CanvasGroup d, float start, float end, float lerpTime = 0.5f)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime; 

        while(true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            d.alpha = currentValue;

            if (percentageComplete >= 1)
            {
                if(d.alpha == 1)
                {
                    istransparent = false;
                }

                if(d.alpha == 0)
                {
                    istransparent = true; 
                }
                break;
            }
            yield return new WaitForEndOfFrame(); 
        }

        Debug.Log("Finished coRoutine"); 
    }
}
