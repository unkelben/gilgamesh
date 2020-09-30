using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pierce : MonoBehaviour
{

    public float pushValueX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

            Vector2 pushBack = collision.transform.parent.position;
            pushBack -= new Vector2 (pushValueX,0);
            collision.transform.parent.position = pushBack;
        }
    }
}
