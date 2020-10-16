using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    walk,
    attack,
    interact
}


public class player_movement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public vector_value startingPosition;



    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update()
    {

        change = Vector3.zero;
        //change.x = Input.GetAxisRaw("Horizontal");
        // change.y = Input.GetAxisRaw("Vertical");
        change.x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        change.y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        if(Input.GetButtonDown("attack")&& currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }
           else if (currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }

        

        //if (change != Vector3.zero)
        // {        {
        //   MoveCharacter();
        //}

    }
    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.33f);
        currentState = PlayerState.walk;
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            transform.Translate(new Vector3(change.x, change.y));
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }









    void MoveCharacter()
    {
        
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
    );

    }
}
