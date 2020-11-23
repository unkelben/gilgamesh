using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatMotion : MonoBehaviour
{
    float origin = 0f;
    public float maxAngle = 10f;

    float counter1 = 0f;
    float counter2 = 0f;
    public float counterInterval = 0.01f;

    public float noisemultiplier = 0.001f;

    public float boatPower = 0f;
    public float friction = 0.2f;
    float maxBoatPower = 60f;
    int lastWaterSpeed = 0;

    bool trigger1 = false;
    bool trigger2 = true;
    
    float wordCounter = 0f;
    float interval = 2000f;

    float threshold1 = 3000f;
    float threshold2 = 1500f;

    public bool textTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter1 += counterInterval;
        counter2 += Mathf.PerlinNoise(counter1,0f) * noisemultiplier;
        float a= origin + maxAngle * Mathf.Sin(counter2);

       transform.eulerAngles = new Vector3(
        transform.eulerAngles.x,
        transform.eulerAngles.y,
        a
       );

        boatPower = Mathf.Min(Mathf.Max(boatPower - friction, 0f), maxBoatPower);
        wordCounter += boatPower/10f;

        if(trigger2 && wordCounter > threshold2)
        {
            trigger1 = true;
            trigger2 = false;
            threshold2 += interval;
           // Debug.Log("EY STARTANIM");
            GameObject.Find("events").GetComponent<boatSceneHandler>().startNextTextAnimation();
                        
        }
        else if(trigger1 && wordCounter > threshold1)
        {
            trigger2 = true;
            trigger1 = false;
            threshold1 += interval;
           // Debug.Log("EY MOVE ON");
            GameObject.Find("events").GetComponent<boatSceneHandler>().moveOn = true;
        }
        //Debug.Log(boatPower);
        int waterSpeed = 7 - Mathf.RoundToInt(boatPower / 10f);
        if (waterSpeed == 7) waterSpeed = 8;
        if(waterSpeed != lastWaterSpeed)
        {
            GameObject.Find("Water").GetComponent<rippleEffect>().travelRate = waterSpeed;
        }
        lastWaterSpeed = waterSpeed;
    }
}
