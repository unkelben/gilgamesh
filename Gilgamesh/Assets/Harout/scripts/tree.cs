using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{

    private Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Break()
    {
        anim.SetBool("break", true);
        StartCoroutine(breakCo());
    }


    IEnumerator breakCo()
    {
        yield return new WaitForSeconds(2F);
        this.gameObject.SetActive(false);
    }

}
