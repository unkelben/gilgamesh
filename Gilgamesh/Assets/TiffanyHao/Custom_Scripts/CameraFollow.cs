using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player_t;
    public GameObject background;
    //private bool movingCam = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var cammoveside = - player_t.gameObject.GetComponent<DivingMovement>().move_side;
        var playerspeed = player_t.gameObject.GetComponent<DivingMovement>().fallingspeed;
        if (cammoveside < 0)
        {
            Debug.Log("cam moving left");
        }
        else if (cammoveside > 0)
        {
            Debug.Log("cam moving right");
        }
        //this script prevents camera from following the player to the right and left bounds of the game scene:
        //basically what it does is the opposite from player movements
        /*move_side = Input.GetAxis("Horizontal");*/ // <0 is left, >0 is right 
        transform.position += new Vector3(cammoveside, 0, 0) * Time.deltaTime * playerspeed;

        //only have camera follows if movingcam == true
        //if (movingcam == true)
        //{
        //    vector3 temp = transform.position;
        //    temp.y = player_t.position.y + 3;
        //    transform.position = new vector3(0, temp.y, this.transform.position.z);
        //}

        //stop camera if it reaches the bottom of the sea
        //For now I can only use hard numbers but if there's a way to automatically track camera position based on background length and cam size then......... I'm all ears
        //var bgH = background.GetComponent<SpriteRenderer>().bounds.size.y;
        //var bottom = -bgH / 2 + 13;
        //if (transform.position.y <= bottom)
        //{
        //    movingCam = false;
        //}

        /**
        Vector3 temp = transform.position;

        temp.x = player_t.position.x;
        temp.y = player_t.position.y;

        transform.position = temp; 
         **/

    }
}
