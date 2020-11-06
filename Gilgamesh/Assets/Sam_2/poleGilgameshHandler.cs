using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poleGilgameshHandler : MonoBehaviour
{
    public Sprite stillImg;
    public Sprite stillWithPoleImg;

    public List<Sprite> walkingImg;
    public List<Sprite> walkingWithPoleImg;
    public List<Sprite> settingPoleImg;
    public List<Sprite> pushBackImg;

    public Sprite stillNoPoleImg;
    public Sprite poleImg;

    public Vector2 stillImgOffset;
    public Vector2 stillWithPoleImgOffset;

    public List<Vector2> walkingImgOffset;
    public List<Vector2> walkingWithPoleImgOffset;
    public List<Vector2> settingPoleImgOffset;
    public List<Vector2> pushBackImgOffset;

    public Vector2 stillNoPoleImgOffset;
    public Vector2 poleImgOffset;


    // animateme stuff:
    public bool running = true;

    int counter = 0;
    public int updatePeriod = 100;
    int animFrame = 0;
    int animLength = 1;
    string animState = "still";

    SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
    }

    void updateFrame(int input, List<Vector2> offsets)
    {
        transform.localPosition = new Vector3(offsets[animFrame].x, offsets[animFrame].y, transform.localPosition.z);
        animFrame = (animFrame + 1) % input;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (running && counter % updatePeriod == 0)
        {
            switch (animState)
            {
                case "still": rend.sprite = stillImg;
                    transform.localPosition = new Vector3(stillImgOffset.x, stillImgOffset.y, transform.localPosition.z); 
                    break;
                case "stillWithPole": rend.sprite = stillWithPoleImg;
                    transform.localPosition = new Vector3(stillWithPoleImgOffset.x, stillWithPoleImgOffset.y, transform.localPosition.z); 
                    break;
                case "stillNoPole": rend.sprite = stillNoPoleImg;
                    transform.localPosition = new Vector3(stillNoPoleImgOffset.x, stillNoPoleImgOffset.y, transform.localPosition.z); 
                    break;
                case "walking":
                    rend.sprite = walkingImg[animFrame];
                    updateFrame(walkingImg.Count, walkingImgOffset);
                    break;
                case "walkingWithPole":
                    rend.sprite = walkingWithPoleImg[animFrame];
                    updateFrame(walkingWithPoleImg.Count, walkingWithPoleImgOffset);
                    break;
                case "settingPole":
                    rend.sprite = settingPoleImg[animFrame];
                    updateFrame(settingPoleImg.Count, settingPoleImgOffset);
                    break;

                case "pushBack":
                    rend.sprite = pushBackImg[animFrame];
                    transform.localPosition = new Vector3(
                        pushBackImgOffset[animFrame].x,
                        pushBackImgOffset[animFrame].y,
                        transform.localPosition.z
                        );

                    animFrame = (animFrame + 1) % pushBackImg.Count;
                    break;
            }
            // rend.sprite = sprites[animFrame];
            

        }
        counter++;


        if (Input.GetKey("1")) startAnimation("still");
        else if (Input.GetKey("2")) startAnimation("stillWithPole");
        else if (Input.GetKey("3")) startAnimation("stillNoPole");
        else if (Input.GetKey("4")) startAnimation("walking");
        else if (Input.GetKey("5")) startAnimation("walkingWithPole");
        else if (Input.GetKey("6")) startAnimation("settingPole");
        else if (Input.GetKey("7")) startAnimation("pushBack");
    }

    public void startAnimation(string state)
    {
        animState = state;
        animFrame = 0;
        counter = 0;
    }
}
