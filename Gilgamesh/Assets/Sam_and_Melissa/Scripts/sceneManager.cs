using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneManager : MonoBehaviour
{
    GameObject scene1;
    GameObject scene2;
    GameObject scene3;

    GameObject bubble1;
    GameObject bubble2;
    GameObject maskBubble;
    GameObject title;

    GameObject councillors;
    GameObject backdrop;
    Color bgColor;
    float trigger = 0f;
    int phase = 0;
    float backdropFadeout = 1f;

    public bool scene1started = false;
    public bool scene1over = false;
    
    // Start is called before the first frame update
    void Start()
    {
        backdrop = GameObject.Find("backdrop");
        bgColor = backdrop.GetComponent<SpriteRenderer>().material.color;
        scene1 = GameObject.Find("Scene1");
        scene2 = GameObject.Find("Scene2");
        scene3 = GameObject.Find("Scene3");
        bubble1 = GameObject.Find("Bubble1");
        bubble2 = GameObject.Find("Bubble2");
        maskBubble = GameObject.Find("MaskBubble");
        title = GameObject.Find("Title");
        councillors = GameObject.Find("council-dudes");

        scene1.SetActive(false);
        scene2.SetActive(false);
        scene3.SetActive(false);

        bubble1.SetActive(false);
        bubble2.SetActive(false);
        maskBubble.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(phase);
        // this the game loooop
        switch (phase)
        {
            // phase 0: wait for mouse click to start scene
            case 0:
                if (Input.GetMouseButtonDown(0))
                {
                    phase = 1;
                }
                break;
            
                // phase 1: title moves out and councillors move in
            case 1:
                Vector3 pos = title.transform.position;
                Vector3 pos2 = councillors.transform.position;

                title.transform.position = new Vector3(pos.x, pos.y + 0.035f, pos.z);
                councillors.transform.position = new Vector3(pos2.x, pos2.y + 0.026f, pos2.z);

                if (title.transform.position.y > 12f)
                {
                    phase = 2;
                    // set time to first bubble
                    trigger = Time.time + 0.5f;
                }
                break;

            // phase 2: bubble1 appears
            case 2:

                if( Time.time > trigger)
                {
                    phase = 3;
                    bubble1.SetActive(true);
                    // set time to second bubble 
                    trigger = Time.time + 0.5f;
                }
                break;

            // phase 3: bubble 2 appears
            case 3:

                if (Time.time > trigger)
                {
                    phase = 4;
                    bubble2.SetActive(true);
                    // set time to mask-bubble 
                    trigger = Time.time + 0.5f;
                }

                break;

            // phase 4: mask bubble appears
            case 4:

                if (Time.time > trigger)
                {
                    phase = 5;
                    maskBubble.SetActive(true);
                    scene1.SetActive(true);
                }

                break;

                // phase 5: move things and grow mask bubble
            case 5:
                Vector3 pos3 = maskBubble.transform.position;
                Vector3 scale = maskBubble.transform.localScale;
                Vector3 pos4 = bubble1.transform.position;
                Vector3 pos5 = bubble2.transform.position;
                Vector3 pos6 = councillors.transform.position;
                float deltaScale = 1.001f;
                float bubbleDeltaX = 0.017f;
                float bubbleDeltaY = 0.01f;

                maskBubble.transform.position = new Vector3(pos3.x -0.05f, pos3.y-0.1f, pos3.z);
                maskBubble.transform.localScale = new Vector3(scale.x* deltaScale, scale.y* deltaScale, scale.z* deltaScale);
                bubble1.transform.position = new Vector3(pos4.x - bubbleDeltaX, pos4.y - bubbleDeltaY, pos4.z);
                bubble2.transform.position = new Vector3(pos5.x + bubbleDeltaX, pos5.y - bubbleDeltaY, pos5.z);
                councillors.transform.position = new Vector3(pos6.x, pos6.y - bubbleDeltaY, pos6.z);

                if (maskBubble.transform.position.y < 3.5f) phase = 6;
                break;

            case 6:
                Vector3 scale2 = maskBubble.transform.localScale;
                Vector3 pos7 = maskBubble.transform.position;
                float deltaScale2 = 1.002f;
                maskBubble.transform.localScale = new Vector3(scale2.x * deltaScale2, scale2.y * deltaScale2, scale2.z * deltaScale2);
                maskBubble.transform.position = new Vector3(pos7.x, pos7.y - 0.004f, pos7.z);

                if (maskBubble.transform.localScale.x > 4f) phase = 7;

                backdropFadeout = Mathf.Max(0f, backdropFadeout - 0.0015f);
                backdrop.GetComponent<SpriteRenderer>().material.color = new Color(bgColor.r,bgColor.g,bgColor.b, backdropFadeout);
                break;

            case 7:
                if (!scene1started)
                {
                    scene1started = true;
                }
                else
                {
                    if (scene1over)
                    {
                        scene1started = false;
                        phase = 8;
                    }
                }
                break;

            case 8:

                break;
        }
    }

    
}
