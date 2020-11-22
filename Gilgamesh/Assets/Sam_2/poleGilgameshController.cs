using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poleGilgameshController : MonoBehaviour
{
    
    GameObject gilgamesh;
    SpriteRenderer gilgaSprite;
    float walkSpeed = 0.014f;

    float acceleration = 0f;
    float velocity = 0f;
    float friction = 0.011f;
    float maxSpeed = 0.5f;

    public float boatBoundMin = -5f;
    public float boatBoundMax = 5f;

    public List<AudioClip> steps;
    AudioSource stepSFX;
    public float stepInterval = 0.2f;
    public float stepPitchMin = 0.7f;
    public float stepPitchMax = 0.85f;
    float nextStep = 0f;

    bool lastMovingState = false;
    bool carryingPole = false;
    bool pushingPole = false;
    bool placingPole = false;
    public bool polePlaced = false;
    bool spacepush = false;
    bool moving = false;
    public bool flipped = false;
    bool shaking = false;
    int shakeCount = 0;
    int shakeLength = 10;
    public bool leftPressed = false;
    public bool rightPressed = false;
    public bool spacePressed = false;
    int poleThreshold = 9;

    int polesLeft;
    public string controlKey = "a";
    public bool ready = false;

    // Start is called before the first frame update
    void Start()
    {
        stepSFX = gameObject.GetComponent<AudioSource>();
        polesLeft = GameObject.Find("events").GetComponent<boatSceneHandler>().polesLeft;
       // Debug.Log(transform.localPosition.x);
        gilgamesh = GameObject.Find("gilga2");
        gilgaSprite = gilgamesh.GetComponent<SpriteRenderer>();
        StartAnimation("still");
       // GameObject.Find("events").GetComponent<boatSceneHandler>().shuffleControl();
    }



    // Update is called once per frame
    void FixedUpdate()
    {

        moving = false;
        if (!polePlaced && !placingPole)
        {
            if (Input.GetKey("left"))
            {
                acceleration = -walkSpeed;
                gilgaSprite.flipX = true;
                flipped = true;
                moving = true;
                leftPressed = true;
            }
            else if (Input.GetKey("right"))
            {
                acceleration = walkSpeed;
                gilgaSprite.flipX = false;
                flipped = false;
                moving = true;
                rightPressed = true;
            }
            else acceleration = 0;
        }
        else
        {
            acceleration = 0;
            flipped = false;
            gilgaSprite.flipX = false;
        }

        if (moving)
        {
            float time = Time.time;
            if (time > nextStep)
            {
                stepSFX.clip = steps[Mathf.FloorToInt(Random.Range(0, steps.Count))];
                stepSFX.pitch = Random.Range(stepPitchMin, stepPitchMax);
                stepSFX.Play();
                nextStep += stepInterval;
            }
        }


            velocity += acceleration;

        
        if (velocity - friction > 0f) velocity -= friction;
        else if (velocity + friction < 0f) velocity += friction;
        else
        {
            velocity = 0f;
        }

        
        if (Mathf.Abs(velocity) > 0.2f) moving = true;


        velocity = Mathf.Min(Mathf.Max(velocity, -maxSpeed), maxSpeed);

        transform.localPosition = new Vector3(
            Mathf.Min(Mathf.Max(transform.localPosition.x + velocity, boatBoundMin), boatBoundMax),
            transform.localPosition.y,
            transform.localPosition.z
            );

        // trigger animations:

        // if player isn't carrying pole
        if (!carryingPole)
        {
            if (moving && !lastMovingState) StartAnimation("walking");
            else if (!moving && lastMovingState) StartAnimation("still");
        }
        // if player is carrying a pole
        else
        {
            if (!pushingPole && !placingPole)
            {
               // Debug.Log("yaaa");
                if (moving && !lastMovingState) StartAnimation("walkingWithPole");
                else if (!moving && lastMovingState) StartAnimation("stillWithPole");
            }
            
        }
        
        lastMovingState = moving;


        
        if (shaking)
        {
            gilgamesh.transform.position = new Vector3(
                gilgamesh.transform.position.x,
                gilgamesh.transform.position.y + 0.032f * Mathf.Sin( 3* Mathf.PI * shakeCount/shakeLength ),
                gilgamesh.transform.position.z
                );
        }

        shakeCount++;
        if (shakeCount > shakeLength) shaking = false;
    }

    public void onPolePlaceEnd()
    {
        placingPole = false;
        polePlaced = true;
    }

    public void onPolePushEnd()
    {
        polePlaced = false;
        carryingPole = false;
    }

    private void Update()
    {
        if (ready&&Input.GetKeyDown(controlKey)&&leftPressed&&rightPressed&&polesLeft >=0)
        {
         //   GameObject.Find("events").GetComponent<boatSceneHandler>().shuffleControl();
            spacePressed = true;
            // spacepush = true;
           // Debug.Log("space!");

            if (!carryingPole)
            {
                
                polesLeft--;
                if (polesLeft >= 0)
                {
                    GameObject.Find("events").GetComponent<boatSceneHandler>().grabPole();
                    carryingPole = true;
                    if (moving) StartAnimation("walkingWithPole");
                    else if (!moving) StartAnimation("stillWithPole");
                }
                else
                {
                    StartAnimation("stillNoPole");
                }
                
            }
            else 
            {
                

                if (polesLeft == poleThreshold)
                {
                    GameObject ev = GameObject.Find("events");
                    ev.GetComponent<boatSceneHandler>().keepPushing();
                    poleThreshold--;
                }
                if (!polePlaced && !placingPole && polesLeft>=0)
                {
                    // start placing pole.
                    placingPole = true;
                    StartAnimation("settingPole");
                }
                else if (polePlaced)
                {
                    if (!pushingPole)
                    {
                        // trigger pushing pole
                        pushingPole = true;
                        StartAnimation("pushBack");
                        
                        Shake();
                        transform.parent.gameObject.GetComponent<boatMotion>().boatPower += 4f;
                    }
                }
            }
        }
        else
        {
            pushingPole = false;
          //  spacepush = false;
        }
    }

    void Shake()
    {
        shaking = true;
        shakeCount = 0;
    }

    void StartAnimation(string name)
    {
        Debug.Log(name);
        gilgamesh.GetComponent<poleGilgameshAnimations>().startAnimation(name);

        if (name == "pushBack") gilgamesh.GetComponent<poleGilgameshAnimations>().pushPower++;
        else gilgamesh.GetComponent<poleGilgameshAnimations>().pushPower = 0;
    }
}
