using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpinNeedles : MonoBehaviour
{

    public Sprite sprite1; // Drag your first sprite here
    public Sprite sprite2; // Drag your second sprite here

    private SpriteRenderer spriteRenderer;

    public GameObject scissorsPrefab;

   


    void Start()
    {
        

        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = sprite1; // set the sprite to sprite1

    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ChangeTheDamnSprite());
        }
    }

    IEnumerator ChangeTheDamnSprite()
    {
        if (spriteRenderer.sprite == sprite1) // if the spriteRenderer sprite = sprite1 then change to sprite2
        {
            yield return new WaitForSeconds(0.5f);
            spriteRenderer.sprite = sprite2;
            UnpinCounter.needleRemovalCounter -= 1;
            
            Debug.Log(UnpinCounter.needleRemovalCounter);

            Vector2 position = new Vector2(2, 0);

            if (UnpinCounter.needleRemovalCounter == 0)
            {
                Instantiate(scissorsPrefab, position, Quaternion.Euler(new Vector3(0, 0, -45)));
            }
        }

    }

}
