using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poleMotion : MonoBehaviour
{

    GameObject water;
    float destroyThreshold = -12f;
    public float forceMult = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        water = GameObject.Find("Water");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(
            transform.position.x - forceMult*(8 - water.GetComponent<rippleEffect>().travelRate),
            transform.position.y, 
            transform.position.z
            );
        if(transform.position.x < destroyThreshold)
        {
            Destroy(gameObject);
        }
    }
}
