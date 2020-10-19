using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    // Options for the sub categories
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject text6;


    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Start()
    {
        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
        text4.SetActive(false);
        text5.SetActive(false);
        text6.SetActive(false);

        // Activate ending
        StartCoroutine("Intro1");
        StartCoroutine("Intro2");
        StartCoroutine("Intro3");
        StartCoroutine("Intro4");
        StartCoroutine("Intro5");
        StartCoroutine("Intro6");
    }

    IEnumerator Intro1()
    {
        yield return new WaitForSeconds(1f);
        text1.SetActive(true);
    }

    IEnumerator Intro2()
    {
        yield return new WaitForSeconds(2.5f);
        text2.SetActive(true);
    }

    IEnumerator Intro3()
    {
        yield return new WaitForSeconds(8f);
        text3.SetActive(true);
    }

    IEnumerator Intro4()
    {
        yield return new WaitForSeconds(16f);
        text4.SetActive(true);
    }

    IEnumerator Intro5()
    {
        yield return new WaitForSeconds(24f);
        text5.SetActive(true);
    }

    IEnumerator Intro6()
    {
        yield return new WaitForSeconds(28f);
        text6.SetActive(true);
    }

    void Update()
    {

    }
}
