using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DivingMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float movementspeed = 10;

    public Rigidbody2D rb;
    private float move_side;
    private float move_down;
    public Slider s;
    public GameObject background;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        //check left right input 
        move_side = Input.GetAxis("Horizontal"); // <0 is left, >0 is right 

        move_down = Input.GetAxis("Vertical");  // positive is up, negative is down 

        if(move_down >= 0)
        {
            move_down = 0; 
        }
        //get screen width and object width
        var screenW = background.GetComponent<SpriteRenderer>().bounds.size.x;
        var objectW = gameObject.GetComponent<BoxCollider2D>().bounds.size.x;
        //if player is moving left and hits left border, block movement
        if (move_side < 0)
        {
            if (transform.position.x <= 0 - screenW / 2 + objectW / 2)
            {
                move_side = 0;
                //Debug.Log("left_boder");
            }
        }
        //if player is moving right and hits right border, block movement
        if (move_side > 0)
        {
            if (transform.position.x >= screenW / 2 - objectW / 2)
            {
                move_side = 0;
                //Debug.Log("right_boder");
            }
        }
        
        transform.position += new Vector3(move_side, move_down, 0) * Time.deltaTime * movementspeed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Flower"))
        {
            SceneManager.LoadScene("GoodEnding"); 
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("hit enemy");
            //Decrease air bar value
            for (int i = 0; i < 1000; i++)
            {
                //s.value -= Airhp.decreaseRate;
                s.value = 0;
            }
            //if air bar value <=0 -> gameover, assign the collided object as last bounty
            if (s.value >= 0)
            {
                PlayerPrefs.SetString("lastBounty", collision.gameObject.GetComponent<EnemyMovement>().enemy_name);
                string lastBounty = PlayerPrefs.GetString("lastBounty");
                Debug.Log(lastBounty);
            }
        }
    }

}
