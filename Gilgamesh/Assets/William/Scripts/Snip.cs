
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snip : MonoBehaviour

{
    public Animator anim;
    public bool snipped = false;

    private AudioSource snipping;

    void Start()
    {
        snipping = GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //anim.Play("Scissors");
            anim.SetTrigger("SnapMe");
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "String" && snipped == true)
        {
            Destroy(collision.gameObject);
        }
    }

    public void snip()
    {
        snipped = true;
        snipping.Play();
    }

    public void snipNot()
    {
        snipped = false;
    }
}
