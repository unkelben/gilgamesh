using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(mainMenu))]
public class personMovement : MonoBehaviour
{
    private float movementX = 0f;
    private float movementY = 0f;

    private float stepX = 0f;
    private float stepY = 0f;

    public Animator animator;
    public Rigidbody2D rbNpc;
    private playerMovement player;

    public readonly string playerMovementX = "playerMovementX";
    public readonly string playerMovementY = "playerMovementY";
    public readonly string selectedCharacter = "selectedCharacter";

    // Start is called before the first frame update
    void Start()
    {
      player = FindObjectOfType<playerMovement>();
    }

    // Called 50 times per second
    void FixedUpdate()
    {
        rbNpc.MovePosition(new Vector2(rbNpc.position.x + movementX * Time.fixedDeltaTime, rbNpc.position.y + movementY * Time.fixedDeltaTime));

        int getCharacter = PlayerPrefs.GetInt(selectedCharacter);

        switch(getCharacter)
        {
          case 0:
            stepX = Random.Range(1f,5f);
            stepY = Random.Range(1f,5f);
            
            animator.SetFloat("Reaction", -1);
            break;
          case 1:
            stepX = Random.Range(5f,10f);
            stepY = Random.Range(5f,10f);

            animator.SetFloat("Reaction", 1);
            break;
        }

        float getX = PlayerPrefs.GetFloat(playerMovementX)*Random.Range(0f,2f);
        float getY = PlayerPrefs.GetFloat(playerMovementY)*Random.Range(0f,2f);

        movementX = -getX/stepX;
        movementY = getY/stepY;
    }
}
