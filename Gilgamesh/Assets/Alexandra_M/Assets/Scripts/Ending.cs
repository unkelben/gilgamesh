using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    // Options for the sub categories
    public GameObject text1;
    public GameObject text2;

    void Start()
    {
        text1.SetActive(false);
        text2.SetActive(false);

        // Activate ending
        StartCoroutine("Ending1");
        StartCoroutine("Ending2");
    }

    IEnumerator Ending1()
    {
        yield return new WaitForSeconds(1f);
        text1.SetActive(true);
    }

    IEnumerator Ending2()
    {
        yield return new WaitForSeconds(3f);
        text2.SetActive(true);
    }

    void Update()
    {

    }

}