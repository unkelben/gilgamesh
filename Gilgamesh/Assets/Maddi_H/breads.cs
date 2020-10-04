using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breads : MonoBehaviour
{
    
    public int breadValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           ScoreManager.instance.ChangeScore(breadValue);
        }
    }

}
