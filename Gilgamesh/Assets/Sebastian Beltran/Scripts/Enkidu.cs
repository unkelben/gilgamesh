using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Enkidu : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D enkiduRigidBody;
    Animator enkiduAnimator;
    public Flowchart flowchart;
    bool allowMovement;
    



    void Start()
    {
        enkiduRigidBody = GetComponent<Rigidbody2D>();
        enkiduAnimator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        allowMovement = flowchart.GetBooleanVariable("allowMovement");
        if (allowMovement == true) { 
            Move();
        }
    }

    private void Move()
    {
        float controlDir = Input.GetAxis("Horizontal");
        Vector2 enkiduVel = new Vector2(controlDir * speed, enkiduRigidBody.velocity.y);

        enkiduRigidBody.velocity = enkiduVel;

        bool playerIsMoving = Mathf.Abs(enkiduRigidBody.velocity.x) > Mathf.Epsilon;
       
        enkiduAnimator.SetBool("Walking", playerIsMoving);
 

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
}
