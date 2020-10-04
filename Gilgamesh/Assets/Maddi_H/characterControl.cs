using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterControl : MonoBehaviour
{
    public float MovementSpeed = 1;
  //  public float JumpForce = 1;
    public bool isGrounded = false;

     Rigidbody2D _rigidbody;
    // Start is called before the first frame update
     void Start()
    {
       
    }

    
    void Update()
    {
       Jump();
       Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
       transform.position += movement * Time.deltaTime * MovementSpeed;
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }
}
