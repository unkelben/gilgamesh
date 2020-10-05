﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Clay;

public class RemoveClay : MonoBehaviour
{
    [SerializeField] GameObject enkidu;

    [SerializeField] GameObject clayPrefab;

    private bool clayRemoved;
    private bool decreaseWeight;
    public float interval;
    public float weightBalance;

    // Start is called before the first frame update
    void Start()
    {
        interval = 0;
        clayRemoved = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            clayRemoved = false;
        }

        //if(decreaseWeight)
        //{
        //    weightBalance = enkidu.GetComponent<Enkidu>().DecreaseWeight(clayPrefab.GetComponent<Clay>().clayWeight);
        //    if (100 - weightBalance <= interval)
        //    {
        //        decreaseWeight = false;
        //    }
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "PinchLimit" && Input.GetMouseButtonDown(0) && enkidu.GetComponent<Enkidu>().clayWeights.Count > 0 && !clayRemoved)
        {
            decreaseWeight = true;
            clayPrefab.GetComponent<Clay>().clayWeight = enkidu.GetComponent<Enkidu>().clayWeights.Pop();
            print(clayPrefab.GetComponent<Clay>().clayWeight);
            GameObject clay = Instantiate(clayPrefab, other.transform.position, Quaternion.identity) as GameObject;
            clay.transform.parent = other.transform.parent;
            clay.tag = "Clay";
            clayRemoved = true;
            interval += clayPrefab.GetComponent<Clay>().clayWeight;
            enkidu.GetComponent<Enkidu>().interval -= clayPrefab.GetComponent<Clay>().clayWeight;
        }
    }
}
