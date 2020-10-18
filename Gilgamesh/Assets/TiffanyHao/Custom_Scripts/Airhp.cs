using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Airhp : MonoBehaviour
{
    public Slider s;

    public GameObject background;
    public GameObject player;
    public float playerpos;
    public float bgH;
    public float depthTier1;
    public float depthTier2;
    public float depthTier3;

    [SerializeField]
    public static float decreaseRate = 0.00015f; 
    // Start is called before the first frame update
    void Start()
    {
        //set the value of the initial air bar to 1 at the start of the game. 
        s.value = 1;
        bgH = background.GetComponent<SpriteRenderer>().bounds.size.y;
        depthTier1 = bgH / 2; //the beginning
        depthTier2 = bgH / 6; // the second tier (1/3 of bgH, above global position)
        depthTier3 = -bgH / 6; // the 3rd tier (2/3 of bgH, below global position)
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerpos = player.transform.position.y;

        if (s.value <= 0)
        {

            SceneManager.LoadScene("BadEnding"); 
        }

        if (playerpos <= depthTier3)
        {
            //Debug.Log("depth tier 3");
            //Debug.Log(depthTier3);
            s.value -= decreaseRate * 6;
        } else if (playerpos <= depthTier2)
        {
            //Debug.Log("depth tier 2");
            //Debug.Log(depthTier2);
            s.value -= decreaseRate*3;
        } else if(playerpos <= depthTier1)
        {
            //Debug.Log("depth tier 1");
            s.value -= decreaseRate; 
        }

        
    }

}
