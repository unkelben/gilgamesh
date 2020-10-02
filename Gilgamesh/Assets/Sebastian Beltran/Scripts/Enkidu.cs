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
    }
}
