using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    // Inspiration https://www.youtube.com/watch?v=whzomFgjT50

    private float moveSpeed = 0f;
    private float stepRange = .1f;

    public Animator animator;
    public Rigidbody2D rb;
    public Vector2 movement;

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
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    // Called 50 times per second
    void FixedUpdate()
    {
        PlayerPrefs.SetFloat(playerMovementX, movement.x);
        PlayerPrefs.SetFloat(playerMovementY, movement.y);

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if(moveSpeed<=stepRange){
          stepRange = Random.Range(0.1f,2.5f);
          moveSpeed+=stepRange/25;
        } else {
          moveSpeed = .5f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Npc"))
      {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
      }
    }
}
