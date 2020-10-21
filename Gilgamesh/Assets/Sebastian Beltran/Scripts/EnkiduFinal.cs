using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class EnkiduFinal : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject lion;
    [SerializeField] Flowchart flowchart;
    Rigidbody2D enkiduRigidBody;
    Animator enkiduAnimator;
    bool isAtacking = false;




    void Start()
    {
        enkiduRigidBody = GetComponent<Rigidbody2D>();
        enkiduAnimator = GetComponent<Animator>();
        enkiduAnimator.Play("Idle Wide");

    }
    // Update is called once per frame
    void Update()
    {
        isAtacking = flowchart.GetBooleanVariable("isAtacking");
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
        if (Input.GetKeyDown(KeyCode.Space) && isAtacking)
        {
            enkiduAnimator.SetBool("Attack", true);
        } else if (Input.GetKeyUp(KeyCode.Space))
        {
            enkiduAnimator.SetBool("Attack", false);
        }
    }

}
