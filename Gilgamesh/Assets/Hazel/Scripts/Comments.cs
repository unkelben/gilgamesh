using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comments : MonoBehaviour
{
    public GameObject comment;
    public bool commenting = false;
    public float sumer = 0;
    public float fem = 0;
    public float thobe = 0;
    public float tie = 0;
    public Sprite sumerSprite;
    public Sprite femSprite;
    public Sprite thobeSprite;
    public Sprite tieSprite;
    public GameObject commentsText;
    private AudioSource source;
    private bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (commenting == true)
        {
            comment.GetComponent<Renderer>().enabled = true;
            if (Input.GetMouseButtonUp(0))
            {
                source.Play();
            }
        }

        else
        {
            comment.GetComponent<Renderer>().enabled = false;
            commentsText.GetComponent<Renderer>().enabled = false;
        }

        if (sumer == 2)
        {
            commenting = true;
            commentsText.GetComponent<Renderer>().enabled = true;
            commentsText.GetComponent<SpriteRenderer>().sprite = sumerSprite;
        }

        else if (fem == 2)
        {
            commenting = true;
            commentsText.GetComponent<Renderer>().enabled = true;
            commentsText.GetComponent<SpriteRenderer>().sprite = femSprite;
        }

        else if (thobe == 3)
        {
            commenting = true;
            commentsText.GetComponent<Renderer>().enabled = true;
            commentsText.GetComponent<SpriteRenderer>().sprite = thobeSprite;
        }

        else if (tie == 4)
        {
            commenting = true;
            commentsText.GetComponent<Renderer>().enabled = true;
            commentsText.GetComponent<SpriteRenderer>().sprite = tieSprite;
        }

        else
        {
            commenting = false;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "enkiPants1")
        {
            sumer += 1;
           
        }
        if (collision.gameObject.name == "enkiHair3")
        {
            sumer += 1;

        }

        if (collision.gameObject.name == "enkiDress0")
        {
            fem += 1;

        }
        if (collision.gameObject.name == "enkiShoes2")
        {
            fem += 1;

        }

        if (collision.gameObject.name == "enkiDress1")
        {
            thobe += 1;

        }
        if (collision.gameObject.name == "enkiHair2")
        {
            thobe += 1;

        }
        if (collision.gameObject.name == "enkiShoes1")
        {
            thobe += 1;

        }
        if (collision.gameObject.name == "enkiShirt0")
        {
            tie += 1;

        }
        if (collision.gameObject.name == "enkiExtra0")
        {
            tie += 1;

        }
        if (collision.gameObject.name == "enkiShoes0")
        {
            tie += 1;

        }
        if (collision.gameObject.name == "enkiPants0")
        {
            tie += 1;

        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "enkiPants1")
        {
            sumer -= 1;

        }
        if (collision.gameObject.name == "enkiHair3")
        {
            sumer -= 1;

        }
        if (collision.gameObject.name == "enkiDress0")
        {
            fem -= 1;

        }
        if (collision.gameObject.name == "enkiShoes2")
        {
            fem -= 1;

        }
        if (collision.gameObject.name == "enkiDress1")
        {
            thobe -= 1;

        }
        if (collision.gameObject.name == "enkiHair2")
        {
            thobe -= 1;

        }
        if (collision.gameObject.name == "enkiShoes1")
        {
            thobe -= 1;

        }
        if (collision.gameObject.name == "enkiShirt0")
        {
            tie -= 1;

        }
        if (collision.gameObject.name == "enkiExtra0")
        {
            tie -= 1;

        }
        if (collision.gameObject.name == "enkiShoes0")
        {
            tie -= 1;

        }
        if (collision.gameObject.name == "enkiPants0")
        {
            tie -= 1;

        }
    }
}
