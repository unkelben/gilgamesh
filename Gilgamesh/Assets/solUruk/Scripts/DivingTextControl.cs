using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivingTextControl : MonoBehaviour
{
    // Start is called before the first frame update

    public CanvasGroup threebuttons;

    public bool istransparent = false; 

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.activeSelf == true) //check if its active
        {
            if (!istransparent)
            {
                FadeOut();
            }
        }
       
    }


    public void FadeOut()
    {
        StartCoroutine(FadeImage(threebuttons, threebuttons.alpha, 0));

    }


    public IEnumerator FadeImage(CanvasGroup d, float start, float end, float lerpTime = 0.9f)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            d.alpha = currentValue;

            if (percentageComplete >= 1)
            {

                if (d.alpha == 0)
                {
                    istransparent = true;
                }
                break;
            }
            yield return new WaitForEndOfFrame();
        }

        Debug.Log("Finished fading 3 buttons");
    }


}
