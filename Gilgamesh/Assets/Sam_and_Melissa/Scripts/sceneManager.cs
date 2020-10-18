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
    GameObject bubble3;
    GameObject bubble4;
    GameObject bubble5;
    GameObject bubble6;
    GameObject maskBubble;
    GameObject title;

    GameObject councillors;
    GameObject backdrop;

    GameObject camera;
    Color bgColor;
    float trigger = 0f;
    int phase = 0;
    float backdropFadeout = 1f;

    public bool scene1started = false;
    public bool scene1over = false;
    int counter = 0;

    Vector3 bubble1InitScale;
    Vector3 bubble2InitScale;
    Vector3 bubble3InitScale;
    Vector3 bubble4InitScale;
    Vector3 bubble5InitScale;
    Vector3 bubble6InitScale;
    Vector3 maskBubbleInitScale;

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
        bubble3 = GameObject.Find("Bubble3");
        bubble4 = GameObject.Find("Bubble4");
        bubble5 = GameObject.Find("Bubble5");
        bubble6 = GameObject.Find("Bubble6");
        bubble1InitScale = bubble3.transform.localScale;
        bubble2InitScale = bubble3.transform.localScale;
        bubble3InitScale = bubble3.transform.localScale;
        bubble4InitScale = bubble4.transform.localScale;
        bubble5InitScale = bubble3.transform.localScale;
        bubble6InitScale = bubble3.transform.localScale;
        
        maskBubble = GameObject.Find("MaskBubble");
        maskBubbleInitScale = maskBubble.transform.localScale;
        title = GameObject.Find("Title");
        councillors = GameObject.Find("council-dudes");
        camera = GameObject.Find("Main Camera");

        scene1.SetActive(false);
        scene2.SetActive(false);
        scene3.SetActive(false);

        bubble1.SetActive(false);
        bubble2.SetActive(false);
        bubble3.SetActive(false);
        bubble4.SetActive(false);
        bubble5.SetActive(false);
        bubble6.SetActive(false);
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

                    bubble1.SetActive(true);
                    bubble2.SetActive(true);
                    maskBubble.SetActive(true);
                    zeroBubble(maskBubble);
                    zeroBubble(bubble1);
                    zeroBubble(bubble2);
                    scene1.SetActive(true);
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
                    counter = 0;
                }
                break;

            // phase 2: bubble1 appears
            case 2:

                if (counter > 50) growBubble(bubble1, bubble1InitScale);
                if (counter > 100) growBubble(bubble2, bubble2InitScale);
                if (counter > 150) growBubble(maskBubble, maskBubbleInitScale);

                
                counter++;

                if (counter > 300)
                {
                    counter = 0;
                    phase = 5;
                }
                break;

           // case 3?
           // case 4?
           // in no case were those ever important forreal


                // phase 5: move camera into mask bubble
            case 5:

                Vector3 camDirection = camera.transform.position - new Vector3(-24.5f, 6.5f, -2f);
                camera.transform.position -= camDirection.normalized * 0.01f * (Mathf.Sin(Mathf.PI*counter/1000f) *2f);
                counter++;

                if (camDirection.magnitude < 0.2f) phase = 6;

                break;

                // phase 6 is scene 1
            case 6:
                if (!scene1started)
                {
                    scene1started = true;
                    bubble1.SetActive(false);
                    bubble2.SetActive(false);
                }
                else
                {
                    if (scene1over)
                    {
                        scene1started = false;
                        counter = 0;
                        phase = 7;
                    }
                }
                break;

                // transition back to council after scene 1
            case 7:

                Vector3 camDirection2 = camera.transform.position - new Vector3(-26.6f, 1f, -10f);
                camera.transform.position -= camDirection2.normalized * 0.01f * (Mathf.Sin(Mathf.PI * counter / 1000f) * 2f);
                counter++;

                if (camDirection2.magnitude < 0.2f)
                {
                    phase = 8;
                    counter = 0;

                    bubble3.SetActive(true);
                    bubble4.SetActive(true);

                    zeroBubble(bubble3);
                    zeroBubble(bubble4);
                }

                break;

                // grow bubbles 3 and 4
            case 8:

                shrinkBubble(maskBubble);

                if (counter > 50) growBubble(bubble3, bubble3InitScale);
                if (counter > 100) growBubble(bubble4, bubble4InitScale);
                

                counter++;

                if(counter > 300)
                {
                    counter = 0;
                    phase = 9;
                }
                break;

            case 9:

                break;
        }
    }

    void zeroBubble(GameObject input)
    {

        input.transform.localScale = new Vector3(0f, 0f, input.transform.localScale.z);
    }
    void shrinkBubble(GameObject input)
    {
        input.transform.localScale = new Vector3(
                    Mathf.Max(0f, input.transform.localScale.x - 0.01f),
                    Mathf.Max(0f, input.transform.localScale.y - 0.01f),
                    input.transform.localScale.z
                    );
    }

    void growBubble(GameObject input, Vector3 scale)
    {
        input.transform.localScale = new Vector3(
                        Mathf.Min(scale.x, input.transform.localScale.x + 0.01f),
                        Mathf.Min(scale.y, input.transform.localScale.y + 0.01f),
                        input.transform.localScale.z
                        );
    }

    
}
