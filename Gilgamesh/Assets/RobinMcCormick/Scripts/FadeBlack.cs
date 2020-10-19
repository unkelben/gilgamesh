using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeBlack : MonoBehaviour
{

    public ChangeBackground cB;
    public Animator fadeAnimator;

    // Start is called before the first frame update
    void Start()
    {
        fadeAnimator = GetComponent<Animator>();
        fadeAnimator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
