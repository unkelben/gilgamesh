using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class clean : MonoBehaviour
{
    public Collider2D bodyCollider;
    public GameObject bubble;
    float elapsedTime = 0;
    public float delay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        elapsedTime += Time.deltaTime;
        Debug.Log(elapsedTime);

        if (Input.GetMouseButtonDown(0) && elapsedTime >= delay)
        {
            if (bodyCollider == Physics2D.OverlapPoint(mousePos))
            {
                elapsedTime = 0;
                 Instantiate(bubble, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.Euler(new Vector3 (0, 0, Random.Range(0, 360))));
           
            }
        }


    }
}
