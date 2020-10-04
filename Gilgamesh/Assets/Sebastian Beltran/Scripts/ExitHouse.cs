using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitHouse : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Enkidu")
        {
            SceneManager.LoadScene("Final Scene");
        }
        
    }
}
