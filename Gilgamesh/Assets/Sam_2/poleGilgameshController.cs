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

    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log(transform.localPosition.x);
        gilgamesh = GameObject.Find("gilga2");
        gilgaSprite = gilgamesh.GetComponent<SpriteRenderer>();
        StartAnimation("still");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        moving = false;

        if (Input.GetKey("a")||Input.GetKey("left"))
        {
            acceleration = -walkSpeed;
            gilgaSprite.flipX = true;
            flipped = true;
            moving = true;
        }
        else if (Input.GetKey("d")||Input.GetKey("right"))
        {
            acceleration = walkSpeed;
            gilgaSprite.flipX = false;
            flipped = false;
            moving = true;
        }
        else acceleration = 0;

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
                Debug.Log("yaaa");
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // spacepush = true;
            Debug.Log("space!");

            if (!carryingPole)
            {
                carryingPole = true;
                if (moving) StartAnimation("walkingWithPole");
                else if (!moving) StartAnimation("stillWithPole");
            }
            else
            {
                if (!polePlaced && !placingPole)
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
