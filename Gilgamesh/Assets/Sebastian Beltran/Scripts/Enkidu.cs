using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enkidu : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D enkiduRigidBody;



    void Start()
    {
        enkiduRigidBody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float controlDir = Input.GetAxis("Horizontal");
        Vector2 enkiduVel = new Vector2(controlDir * speed, enkiduRigidBody.velocity.y);

        enkiduRigidBody.velocity = enkiduVel;

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
