using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poleGilgameshAnimations : MonoBehaviour
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

    public int pushPower = 0;
    // animateme stuff:
    public bool running = true;

    int counter = 0;
    public int updatePeriod = 100;
    int animFrame = 0;
    int animLength = 1;
    string animState = "still";
    string lastState = "";
    public bool polePlaced = false;
    SpriteRenderer rend;
    Vector2 baseOffset;

    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
    }

    void updateFrame(int input, List<Vector2> offsets)
    {
        transform.localPosition = new Vector3(offsets[animFrame].x+baseOffset.x, offsets[animFrame].y, transform.localPosition.z);

        if (animState == "settingPole" && !polePlaced && animFrame == 3)
        {
            transform.parent.gameObject.GetComponent<poleGilgameshController>().onPolePlaceEnd();
            polePlaced = true;
        }
            
        else if(!polePlaced)
        {
            animFrame = (animFrame + 1) % input;
        }
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (running && counter % updatePeriod == 0)
        {
            baseOffset = new Vector2(0f, 0f);

            switch (animState)
            {
                case "still": rend.sprite = stillImg;
                    transform.localPosition = new Vector3(stillImgOffset.x, stillImgOffset.y, transform.localPosition.z); 
                    break;
                case "stillWithPole": rend.sprite = stillWithPoleImg;
                    checkBaseOffset();
                    transform.localPosition = new Vector3(stillWithPoleImgOffset.x+baseOffset.x, stillWithPoleImgOffset.y, transform.localPosition.z); 
                    break;
                case "stillNoPole": rend.sprite = stillNoPoleImg;
                    transform.localPosition = new Vector3(stillNoPoleImgOffset.x, stillNoPoleImgOffset.y, transform.localPosition.z); 
                    break;
                case "walking":
                    rend.sprite = walkingImg[animFrame];
                    updateFrame(walkingImg.Count, walkingImgOffset);
                    break;
                case "walkingWithPole":
                    checkBaseOffset();
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

                    if (pushPower >= 13)
                    {
                        pushPower = 0;
                        startAnimation("stillNoPole");
                        transform.parent.gameObject.GetComponent<poleGilgameshController>().onPolePushEnd();
                    }
                    if (pushPower >= 10) animFrame = 2;
                    else if (pushPower >= 5) animFrame = 1;
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

    void checkBaseOffset()
    {
        if (transform.parent.gameObject.GetComponent<poleGilgameshController>().flipped)
        {
            baseOffset = new Vector2(-4f, 0f);
        }
        else
        {
            baseOffset = new Vector2(0f, 0f);
        }
    }

    public void startAnimation(string state)
    {
        animState = state;

        if (state != "pushBack" || lastState != "pushBack")
            animFrame = 0;

        
      // else if(animFrame>0) animFrame--;
        counter = 0;
        polePlaced = false;
        lastState = state;

    }
}
