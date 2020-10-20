using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class endingText : MonoBehaviour
{
    public TextMeshProUGUI ending;


    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(TextUpdate());
    }

    IEnumerator TextUpdate()
    {
        yield return new WaitForSeconds(1);
        ending.SetText("And thus Enkidu dreamt alone in his sickness...");
        yield return new WaitForSeconds(4);
        ending.SetText("And the harlot was blessed with countless riches, her happiness pilfered from others...");
        yield return new WaitForSeconds(20);

    }
    void Update()
    {
        
    }
}
