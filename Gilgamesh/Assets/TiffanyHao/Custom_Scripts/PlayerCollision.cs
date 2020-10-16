using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public Slider s;
    public GameObject player;

    public AudioClip gasp; 
    AudioSource a; 

    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Gilgamesh colliding");
        if (collision.gameObject.CompareTag("Flower"))
        {
            SceneManager.LoadScene("GoodEnding");
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ////Debug.Log("hit enemy");
            //Decrease air bar value
            for (int i = 0; i < 1000; i++)
            {
                s.value -= Airhp.decreaseRate;
                //s.value = 0;
            }
            //if air bar value <=0 -> gameover, assign the collided object as last bounty
            if (s.value >= 0)
            {
                //play audio cue
                a.PlayOneShot(gasp); 

                PlayerPrefs.SetString("lastBounty", collision.gameObject.GetComponent<EnemyMovement>().enemy_name);
                string lastBounty = PlayerPrefs.GetString("lastBounty");
                //Debug.Log(lastBounty);
            }
        }
        if (collision.gameObject.CompareTag("Wall_left"))
        {
            player.gameObject.GetComponent<DivingMovement>().wall_collidedleft = true;
            Debug.Log("collide wall left");
        }
        else if (collision.gameObject.CompareTag("Wall_right"))
        {
            player.gameObject.GetComponent<DivingMovement>().wall_collidedright = true;
            //Debug.Log("collide wall");
        } 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall_left"))
        {
            player.gameObject.GetComponent<DivingMovement>().wall_collidedleft = false;
            //Debug.Log("collide wall");
        }
        else if (collision.gameObject.CompareTag("Wall_right"))
        {
            player.gameObject.GetComponent<DivingMovement>().wall_collidedright = false;
            //Debug.Log("collide wall");
        }
    }
}
