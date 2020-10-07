using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Controller : MonoBehaviour
{
    public Animator animator;

    public void Flash()
    {
        animator.SetTrigger("Flash");
    }


}
