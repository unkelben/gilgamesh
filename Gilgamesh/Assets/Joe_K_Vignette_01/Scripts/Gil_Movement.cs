using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gil_Movement : MonoBehaviour
{
    public Animator animator; // identifies the animator in order for it to be accessed from the script.
    public float horDir; //controls the direction the player sprite is facing in horizontal.
    public float verDir; //controls the direction the player sprite is facing in Vertical.
    Vector2 horMove = new Vector2(1.0f, 0.0f); //holds base horizonal movement.
    Vector2 verMove = new Vector2(0.0f, 1.0f); //holds base vertical movement.
    public Rigidbody2D playerRB; //holds player's rigidbody.
    public float speed; //holds speed value.
    public int idlewalk = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpriteAnimationController();
        Moving();
    }
    void SpriteAnimationController()
    {
        horDir = Input.GetAxisRaw("Horizontal");
        verDir = Input.GetAxisRaw("Vertical");
        Vector2 side = playerRB.transform.localScale;
        if (verDir < 0)
        {
            idlewalk = 1;
        }
        if (verDir > 0)
        {
            idlewalk = 2;
        }
        if(horDir!= 0)
        {
            side.x = horDir;
            idlewalk = 3;
        }
        if( verDir == 0 && horDir == 0)
        {
            idlewalk = 0;
        }
        playerRB.transform.localScale = side;
        animator.SetInteger("IdlyWalking", idlewalk);
    }

    void Moving()
    {
        playerRB.position += (horMove * horDir * speed * Time.deltaTime);
        playerRB.position += (verMove * verDir * speed * Time.deltaTime);
    }
}
