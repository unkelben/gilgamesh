using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;

public class room_transition : MonoBehaviour
{


    public Vector2 cameraChange;
    public Vector3 playerChange;
    private camera_movement cam;
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;
    public GameObject enkidu;
    public GameObject timer;


    public GameObject dialogueBox;
    public Text dialogueText;
    public string dialog;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<camera_movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.CompareTag("Player"))
        {
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            other.transform.position += playerChange;
            timer.SetActive(true);
            if (needText)
            {
                StartCoroutine(placenameCo());
            }

            

        }

        if (other.CompareTag("Player"))
        {
            enkidu.SetActive(false);
           
        }

    }


    private IEnumerator placenameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        dialogueBox.SetActive(true);
        dialogueText.text = dialog;
        yield return new WaitForSeconds(3f);
        text.SetActive(false);
        dialogueBox.SetActive(false);

    }


}
