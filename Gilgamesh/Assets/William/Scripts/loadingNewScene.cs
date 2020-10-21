using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadingNewScene : MonoBehaviour

    
{
    int yesSir;

    private AudioSource sceneDone;

    GameObject[] Needles;
    // Start is called before the first frame update
    void Start()
    {
        sceneDone = GetComponent<AudioSource>();

        StartCoroutine(Nextscene());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Nextscene()
    {
        while (true)
        {


            Needles = GameObject.FindGameObjectsWithTag("Needle");
            yesSir = Needles.Length;
            yield return new WaitForSeconds(5);
            if (yesSir <= 0)
            {
                sceneDone.Play();
                SceneManager.LoadScene("InterludeWilliam", LoadSceneMode.Single);
            }

        }
    }
}
