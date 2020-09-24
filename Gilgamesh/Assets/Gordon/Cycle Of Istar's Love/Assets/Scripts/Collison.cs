using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collison : MonoBehaviour 
{ 
    public GameObject heart;
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
{
    Debug.Log("hit detected");

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Held");
        }
        else
        {
            heart.transform.position = respawnPoint.transform.position;
        }

    }
}

