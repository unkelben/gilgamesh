using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using System;

public class DivingMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public float movementspeed = 10;

    [SerializeField]
    public float fallingspeed = 10;

    [SerializeField]
    private float constant_fall = -1;

    public bool wall_collidedleft = false;
    public bool wall_collidedright = false;

    public GameObject playerobject;
    public Rigidbody2D rb;
    public float move_side;
    private float move_down;
    public Slider s;
    public GameObject background;

    private bool ismovingUp = false;

    private bool cooldown = false;

    //Platyer sounds
    public AudioClip gasping;
    public AudioClip bubbles;
    public AudioSource A;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerPrefs.SetString("lastBounty", "Nothing");
        A = GetComponent<AudioSource>(); 
    }

    private float forceAmount = 5f;
    void Update()
    {
        //check left right input 
        move_side = Input.GetAxis("Horizontal"); // <0 is left, >0 is right 

        move_down = Input.GetAxis("Vertical");  // positive is up, negative is down

        move_down = -1; // always moving down

        if (move_side < 0 && wall_collidedleft == true) {
            move_side = 0;
            //Debug.Log(wall_collidedleft);
        }

        else if (move_side > 0 && wall_collidedright == true)
        {
            move_side = 0;
        }


        //if(move_down >= 0)
        //{
        //    transform.position += new Vector3(move_side, move_down, 0) * Time.deltaTime * movementspeed; 
        //}

        //transform.position += new Vector3(move_side, move_down, 0) * Time.deltaTime * movementspeed;

 

        if (Input.GetKeyDown("up"))
        {
            if (cooldown == false)
            {
                ismovingUp = true;
                AddForce();
                Invoke("ResetCooldown", 0.5f); //wait for 0.5 sec to prevent button spamming
                cooldown = true;
            }
        } else
        
        if (ismovingUp == false)
        {
            transform.position += new Vector3(move_side, constant_fall, 0) * Time.deltaTime * fallingspeed;
            if (move_side < 0)
            {
                Debug.Log(move_side);
            }
        }

    }

    void AddForce()
    {
        StartCoroutine(FakeAddForceMotion());
    }

    IEnumerator FakeAddForceMotion()
    {
        float i = 0.1f;
        while (forceAmount > i && forceAmount / i > forceAmount*2)
        {
            rb.velocity = new Vector2(rb.velocity.x, forceAmount / i); // !! For X axis positive force
            i = i + Time.deltaTime;
            yield return new WaitForEndOfFrame();
            //Debug.Log(forceAmount / i);
        }
        rb.velocity = Vector2.zero;
        yield return null;
        //Debug.Log("something changes");
        ismovingUp = false;
    }

    void ResetCooldown()
    {
        cooldown = false;
    }



}
