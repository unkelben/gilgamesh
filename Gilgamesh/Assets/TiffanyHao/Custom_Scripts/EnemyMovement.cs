using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public string direction;
    public GameObject background;
    public string enemy_name;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //get screen width and object width
        var screenW = background.GetComponent<SpriteRenderer>().bounds.size.x;
        var objectW = gameObject.GetComponent<CapsuleCollider2D>().bounds.size.x;
        if (transform.position.x <= 0 - screenW / 2 - objectW/2)
        {
            direction = "left";
        }
        if (transform.position.x >= screenW / 2 + objectW/2)
        {
            direction = "right";
        }
        //Debug.Log(direction);

        if (direction == "left")
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;
        }
        if (direction == "right")
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
        }

    }
}
