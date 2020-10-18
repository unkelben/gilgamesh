using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    private float moveSpeed = 2f;
    private int stepRange = 0; // over 10

    public Animator animator;
    public Rigidbody2D rb;
    public Vector2 movement;
    // private Vector2 target;

    public readonly string playerMovementX = "playerMovementX";
    public readonly string playerMovementY = "playerMovementY";

    // Start is called before the first frame update
    void Start()
    {
      GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
      // Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      //
      // if (Input.GetMouseButtonDown(0))
      // {
      //   target = new Vector2(mousePos.x, mousePos.y);
      // }
      movement.x = Input.GetAxisRaw("Horizontal");
      movement.y = Input.GetAxisRaw("Vertical");

      animator.SetFloat("Horizontal", movement.x);
      animator.SetFloat("Vertical", movement.y);
      animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    // Called 50 times per second
    void FixedUpdate()
    {
      if (moveSpeed>=stepRange)
      {
        for (int i = 0;i < 10; i++)
        {
          stepRange++;
          moveSpeed+=stepRange/10;
        }
      }
      else {
        moveSpeed = 2f;
        stepRange = 5;
      }
      // if (target.x <= transform.position.x && target.y <= transform.position.y)
      // {
      //   transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * moveSpeed);
      // }

      PlayerPrefs.SetFloat(playerMovementX, movement.x);
      PlayerPrefs.SetFloat(playerMovementY, movement.y);

      rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Npc"))
      {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Destroy(this.gameObject);
      }
      if (collision.CompareTag("Uruk"))
      {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
      }
    }
}
