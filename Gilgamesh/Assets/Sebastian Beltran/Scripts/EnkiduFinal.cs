using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnkiduFinal : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D enkiduRigidBody;
    Animator enkiduAnimator;



    void Start()
    {
        enkiduRigidBody = GetComponent<Rigidbody2D>();
        enkiduAnimator = GetComponent<Animator>();
        enkiduAnimator.Play("Idle Wide");

    }
    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
    }

    private void Move()
    {
        float controlDir = Input.GetAxis("Horizontal");
        Vector2 enkiduVel = new Vector2(controlDir * speed, enkiduRigidBody.velocity.y);

        enkiduRigidBody.velocity = enkiduVel;

        bool playerIsMoving = Mathf.Abs(enkiduRigidBody.velocity.x) > Mathf.Epsilon;
       
        enkiduAnimator.SetBool("Running", playerIsMoving);
 

        Flip();
    }

    private void Flip()
    {
        bool playerIsMoving = Mathf.Abs(enkiduRigidBody.velocity.x) > Mathf.Epsilon;

        if (playerIsMoving)
        {
            transform.localScale = new Vector2 (Mathf.Sign(enkiduRigidBody.velocity.x) / 4, 0.25f);
        }

    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            enkiduAnimator.SetBool("Attack", true);
        } else if (Input.GetKeyUp(KeyCode.X))
        {
            enkiduAnimator.SetBool("Attack", false);
        }
    }
}
