using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterControl : MonoBehaviour
{
    public float MovementSpeed = 1;
    //  public float JumpForce = 1;
    public bool isGrounded = false;

    //Gordon added:
    private SpriteRenderer CharSprite;
    //Gordon added:
    public Sprite PackForest01_5;
    //Gordon added:
    public Sprite PackForest01_8;

    //Gordon added
    int Bread = 0;

    Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    void Start()
    {

        //Gordon added
        CharSprite = gameObject.GetComponent<SpriteRenderer>();
        //Gordon added
        CharSprite.sprite = PackForest01_5;


    }


    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * MovementSpeed;

        // changing sprite 

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bread"))
        {
            Destroy(other.gameObject);
            //Gordon added
            Bread++;
            //Gordon added:
            CheckNumberOfEaten();
        }
    }

    //Gordon added:
    public void CheckNumberOfEaten(){
        //Gordon added:
        if (Bread >= 7)
        {
            //Gordon added:
            CharSprite.sprite = PackForest01_8;
        }
}

    
}
