using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadingNewScene : MonoBehaviour

    
{
    int yesSir;

    GameObject[] Needles;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(NextScene());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator NextScene()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);

            Needles = GameObject.FindGameObjectsWithTag("Needle");
            yesSir = Needles.Length;
            if (yesSir <= 0)
            {

                SceneManager.LoadScene("IntroWilliam", LoadSceneMode.Single);
            }

        }
    }
}
