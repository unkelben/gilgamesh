using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Pierce : MonoBehaviour
{


    public float pushValueY;

    public Animator animator;

    private GameObject somethingTarget;

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

            somethingTarget = collision.gameObject;
            StartCoroutine(FadeoutDie());

            Vector2 pushBack = collision.transform.parent.position;
            pushBack -= new Vector2 (0, pushValueY);
            collision.transform.parent.position = pushBack;
        }
        
        
        
    }

    IEnumerator FadeoutDie()
    {
        animator.SetTrigger("fade");

        yield return new WaitForSeconds(0.2f);
        Destroy(somethingTarget);
        Destroy(this.gameObject);
    }
}
