using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{
    public new Vector3 location;
    public Sprite on;
    // Start is called before the first frame update
    void Start()
    {   

    }

    void OnCollisionStay2D(Collision2D collision)
    {

        this.transform.position = location;
        this.GetComponent<SpriteRenderer>().sprite = on;

    }



}
