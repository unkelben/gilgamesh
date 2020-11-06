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
        Debug.Log(boatPower);
        int waterSpeed = 7 - Mathf.RoundToInt(boatPower / 10f);
        if(waterSpeed != lastWaterSpeed)
        {
            GameObject.Find("Water").GetComponent<rippleEffect>().travelRate = waterSpeed;
        }
        lastWaterSpeed = waterSpeed;
    }
}
