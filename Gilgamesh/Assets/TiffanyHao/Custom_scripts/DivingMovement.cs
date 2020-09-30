using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivingMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float movementspeed = 10;

    public Rigidbody2D rb;
    private float move_side;
    private float move_down; 
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        //check left right input 
        move_side = Input.GetAxis("Horizontal"); // <0 is left, >0 is right 

        move_down = Input.GetAxis("Vertical");  // positive is up, negative is down 

        if(move_down >= 0)
        {
            move_down = 0; 
        }
        
        transform.position += new Vector3(move_side, move_down, 0) * Time.deltaTime * movementspeed;
       

    }
}
