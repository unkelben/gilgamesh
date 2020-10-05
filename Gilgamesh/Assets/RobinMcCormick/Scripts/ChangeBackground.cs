using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public Sprite backgroundSprite2;
    public Sprite backgroundSprite3;
    public Sprite backgroundSprite4;

    public int interactionAmount;


    // Start is called before the first frame update
    void Start()
    {
        //  SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        interactionAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactionAmount == 1)
        {
            print("background changed");
            GameObject bg2 = new GameObject("enkidu_bg2", typeof(SpriteRenderer));
            SpriteRenderer bg2Renderer = bg2.GetComponent<SpriteRenderer>();
            bg2Renderer.sprite = backgroundSprite2;
            bg2Renderer.sortingLayerName = "background";
            bg2Renderer.sortingOrder = 2;
        }

        if (interactionAmount == 2)
        {
            print("e key was pressed");
            GameObject bg3 = new GameObject("enkidu_bg3", typeof(SpriteRenderer));
            SpriteRenderer bg3Renderer = bg3.GetComponent<SpriteRenderer>();
            bg3Renderer.sprite = backgroundSprite3;
            bg3Renderer.sortingLayerName = "background";
            bg3Renderer.sortingOrder = 3;
        }

        if (interactionAmount == 3)
        {
            print("r key was pressed");
            GameObject bg4 = new GameObject("enkidu_bg4", typeof(SpriteRenderer));
            SpriteRenderer bg4Renderer = bg4.GetComponent<SpriteRenderer>();
            bg4Renderer.sprite = backgroundSprite4;
            bg4Renderer.sortingLayerName = "background";
            bg4Renderer.sortingOrder = 4;
        }
    }
}
