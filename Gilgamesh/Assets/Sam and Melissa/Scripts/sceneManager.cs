using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneManager : MonoBehaviour
{
    GameObject scene1;
    GameObject scene2;
    GameObject scene3;
    // Start is called before the first frame update
    void Start()
    {
        scene1 = GameObject.Find("Scene1");
        scene2 = GameObject.Find("Scene2");
        scene3 = GameObject.Find("Scene3");

        scene1.SetActive(false);
        scene2.SetActive(false);
        scene3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
