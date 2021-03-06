using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public readonly string playerPosX = "playerPosX";
    public readonly string playerPosY = "playerPosY";

    void Start()
    {
      player = FindObjectOfType<playerMovement>();
    }

    void FixedUpdate()
    {
        rbNpc.MovePosition(new Vector2(rbNpc.position.x + movementX * Time.fixedDeltaTime, rbNpc.position.y + movementY * Time.fixedDeltaTime));

        int getCharacter = PlayerPrefs.GetInt(selectedCharacter);

        float getX = PlayerPrefs.GetFloat(playerMovementX)*Random.Range(0f,2f);
        float getY = PlayerPrefs.GetFloat(playerMovementY)*Random.Range(0f,2f);

        float distanceAreaSigned = (PlayerPrefs.GetFloat(playerPosX) - rbNpc.position.x) * (PlayerPrefs.GetFloat(playerPosY) - rbNpc.position.y);

        float distanceArea = Mathf.Abs(distanceAreaSigned);
        Debug.Log(distanceArea);

        switch(getCharacter)
        {
          case 0:
            stepX = Random.Range(10f,15f);
            stepY = Random.Range(10f,15f);
            if (distanceArea < 2f) {
              animator.SetFloat("Reaction", -1);
            }
            else
            {
              animator.SetFloat("Reaction", 0);

              movementX = -getX/stepX;
              movementY = getY/stepY;
            }
            break;
          case 1:
            stepX = Random.Range(5f,10f);
            stepY = Random.Range(5f,10f);

            if (distanceArea < 2f) {
              animator.SetFloat("Reaction", 1);

              movementX = getX/stepX;
              movementY = -getY/stepY;
            }
            else
            {
              animator.SetFloat("Reaction", 0);
            }
            break;
        }
    }
}
