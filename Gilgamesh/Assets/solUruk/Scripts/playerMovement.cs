using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Inspiration https://www.youtube.com/watch?v=whzomFgjT50

    private float moveSpeed = 0f;
    private float stepRange = .1f;

    public Animator animator;
    public Rigidbody2D rb;

    public Vector2 movement;

    // Update is called once per frame
    void Update(){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    // Called 50 times per second
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if(moveSpeed<=stepRange){
          stepRange = Random.Range(0.1f,2.5f);
          moveSpeed+=stepRange/25;
        } else {
          moveSpeed = .5f;
        }
    }
}
