using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnkiduCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cup"))
        {
            Debug.Log("Cup touched Enkidu");
        }

        if (other.gameObject.CompareTag("Rag"))
        {
            Debug.Log("Rag touched Enkidu");
        }
    }
}
