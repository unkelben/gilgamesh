using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Airhp : MonoBehaviour
{
    public int curAir = 0; 
    public int maxAir = 100;

    public int decreaseRate = 5;

    //to check 
    //public Airbar airb; 
    // Start is called before the first frame update
    void Start()
    {
        curAir = maxAir; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void DecreaseAir()
    {
        curAir -= decreaseRate;

        //airb.setAir(curAir); 
    }
}
