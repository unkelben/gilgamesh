using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetHandler : MonoBehaviour
{
    GameObject boat;
    public float windPower = 1f;
    // Start is called before the first frame update
    void Start()
    {
        boat = GameObject.Find("boat");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GustOfWind")
        {
            boat.GetComponent<boatMotion>().boatPower += windPower;
        }
    }
}
