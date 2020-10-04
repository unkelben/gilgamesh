using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personMovement : MonoBehaviour
{
    private float movementX = 0f;
    private float movementY = 0f;

    private float stepX = 0f;
    private float stepY = 0f;

    public playerMovement player;
    public Rigidbody2D rbNpc;

    // Start is called before the first frame update
    void Start(){
      player = FindObjectOfType<playerMovement>();
    }

    // Called 50 times per second
    void FixedUpdate()
    {
        rbNpc.MovePosition(new Vector2(rbNpc.position.x + movementX * Time.fixedDeltaTime, rbNpc.position.y + movementY * Time.fixedDeltaTime));

        stepX = Random.Range(1f,10f);
        stepY = Random.Range(1f,stepX);

        movementX = player.movement.x/stepX;
        movementY = player.movement.y/stepY;

        // if (player.rb.position.x-rbNpc.position.x<=-10f) {}
    }
}
