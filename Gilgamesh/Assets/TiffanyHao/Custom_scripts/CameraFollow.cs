using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player_t;
    public GameObject background;
    private bool movingCam = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {      
        //only have camera follows if movingCam == true
        if (movingCam == true)
        {
            Vector3 temp = transform.position;
            temp.y = player_t.position.y - 5;
            transform.position = new Vector3(0, temp.y, this.transform.position.z);
        }

        //stop camera if it reaches the bottom of the sea
        //For now I can only use hard numbers but if there's a way to automatically track camera position based on background length and cam size then......... I'm all ears
        var bgH = background.GetComponent<SpriteRenderer>().bounds.size.y;
        var bottom = -bgH / 2 + 13;
        if (transform.position.y <= bottom)
        {
            movingCam = false;
        }

        /**
        Vector3 temp = transform.position;

        temp.x = player_t.position.x;
        temp.y = player_t.position.y;

        transform.position = temp; 
         **/

    }
}
