using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Attack : MonoBehaviour
{
    [SerializeField] Flowchart flowchart;
    bool enkiduIsNear;

    private void Update()
    {
        if (enkiduIsNear == true && Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
            flowchart.ExecuteBlock("Last Dialogue");

        }

        Debug.Log(enkiduIsNear);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enkidu")
        {
            enkiduIsNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enkidu")
        {
            enkiduIsNear = false;
        }
    }

    
}
