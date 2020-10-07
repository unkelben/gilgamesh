using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Circle_Behaviour : MonoBehaviour
{
    public Animator animator;
    public GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetTrigger("Expand");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Block"))
        {
            collision.gameObject.GetComponent<Block_Controller>().Flash();
            //Destroy(self);
        }
    }

    public void DestroySelf()
    {
        Destroy(self);
    }
}
