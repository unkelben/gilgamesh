using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    private float moveSpeed = 2f;
    private int stepRange = 0;

    public Animator animator;
    public Rigidbody2D rb;
    public Vector2 movement;

    public readonly string playerMovementX = "playerMovementX";
    public readonly string playerMovementY = "playerMovementY";

    public readonly string playerPosX = "playerPosX";
    public readonly string playerPosY = "playerPosY";

    public readonly string oncePlayedthrough = "oncePlayedthrough";

    void Start()
    {
      GameObject.DontDestroyOnLoad(this.gameObject);
    }

    void FixedUpdate()
    {
      transform.localScale = new Vector2(0.1396339f, 0.1396339f);

      movement.x = Input.GetAxisRaw("Horizontal");
      movement.y = Input.GetAxisRaw("Vertical");

      animator.SetFloat("Horizontal", movement.x);
      animator.SetFloat("Vertical", movement.y);
      animator.SetFloat("Speed", movement.sqrMagnitude);

      if (moveSpeed>=stepRange)
      {
        for (int i = 0; i < 10; i++)
        {
          stepRange++;
          moveSpeed+=stepRange/10;
        }
      }
      else {
        moveSpeed = 2f;
        stepRange = 0;
      }
      PlayerPrefs.SetFloat(playerMovementX, movement.x);
      PlayerPrefs.SetFloat(playerMovementY, movement.y);

      rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

      PlayerPrefs.SetFloat(playerPosX, rb.position.x);
      PlayerPrefs.SetFloat(playerPosY, rb.position.y);

      float isPlayedthrough = PlayerPrefs.GetFloat(oncePlayedthrough);
      if (isPlayedthrough==1)
      {
        Destroy(this.gameObject);
      }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Npc"))
      {
        SceneManager.LoadScene("tavern");
        Destroy(this.gameObject);
      }
      if (collision.CompareTag("Uruk"))
      {
        SceneManager.LoadScene("uruk");
      }
    }
}
