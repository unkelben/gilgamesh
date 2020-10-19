using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBox : MonoBehaviour
{
    public AudioClip wind;
    public AudioClip mainTheme;
    AudioSource B;

    public DivingMovement diving;

    private bool isSwimming; 

    private bool windPlaying = false; 
    private bool mainPlaying = false; 
    // Start is called before the first frame update
    void Start()
    {
        B = GetComponent<AudioSource>();
        B.loop = true; 
    }

    // Update is called once per frame
    void Update()
    {
        isSwimming = diving.playerSwimming;

        if (!isSwimming)
        {
            
            if(mainPlaying)
            {
                B.Stop();
                mainPlaying = false; 
            }
            

            if(!windPlaying)
            {
                //B.loop = true; 
                B.clip = wind;
                B.Play();
                windPlaying = true; 
            }
        }

        if(isSwimming)
        {
            //Debug.Log("Is swimming music change"); 
            if(windPlaying)
            {
                B.Stop();
                windPlaying = false; 
            }
            
            if(!mainPlaying)
            {
                B.clip = mainTheme;
                B.Play();
                mainPlaying = true;

            }
            
        }
    }
}
