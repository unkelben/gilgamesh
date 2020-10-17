using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlCollide : MonoBehaviour
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
        if (other.gameObject.CompareTag("Rag"))
        {
            Debug.Log("Rag touched Bowl");
            // animation of rag dipping into bowl
            // sfx of rag dipping into bowl
            // animation of rag back on table
        }
    }
}
