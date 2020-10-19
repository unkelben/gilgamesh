using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{

    public SpriteRenderer spriteR;
    public Sprite backgroundSprite2;
    public Sprite backgroundSprite3;
    public Sprite backgroundSprite4;

    public int interactionAmount;


    // Start is called before the first frame update
    void Start()
    {
        interactionAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactionAmount == 1)
        {
            print("background changed");
            spriteR.sprite = backgroundSprite2;
        }

        if (interactionAmount == 2)
        {
            print("background changed 2");
            spriteR.sprite = backgroundSprite3;
        }

        if (interactionAmount == 3)
        {
            print("background changed 3");
            spriteR.sprite = backgroundSprite4;
        }
    }
}
