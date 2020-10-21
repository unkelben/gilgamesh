using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Circle_Spawn : MonoBehaviour
{
    float startTime = 0f;
    float coolDown = 1.5f;
    Vector2 mousePosition;
    public GameObject circlePrefab;
    float randomController;
    float randomMultiplierX;
    float randomMultiplierY;
    public Vector2 randomVector;
    private void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Click();
    }

    void Click()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            if(Time.time > startTime + coolDown)
            {
                randomMultiplierX = Random.Range(-200, 200);
                randomMultiplierY = Random.Range(-200, 200);
                randomController = Random.Range(1,100);
                if (randomController >= 33)
                {
                    randomVector = new Vector2(randomMultiplierX/100, randomMultiplierY/100);
                }
                Instantiate(circlePrefab, mousePosition + randomVector, Quaternion.identity);
                startTime = Time.time;
            }
        }
    }
}
