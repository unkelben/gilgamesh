using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pierce : MonoBehaviour
{

    public float pushValueY;
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
            pushBack -= new Vector2 (0, pushValueY);
            collision.transform.parent.position = pushBack;
        }
    }
}
