using MoonSharp.VsCodeDebugger.SDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_Arm_Sprite : MonoBehaviour
{
    public Sprite sprite1; // Drag your first sprite here
    public Sprite sprite2; // Drag your second sprite here

    private SpriteRenderer spriteRenderer;

    private AudioSource laughing;

    void Start()
    {
        laughing = GetComponent<AudioSource>();

        spriteRenderer = GetComponent<SpriteRenderer>(); 
        if (spriteRenderer.sprite == null) 
            spriteRenderer.sprite = sprite1; 
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Needle")
        {
           
            StartCoroutine(ChangeTheDamnSprite()); // call method to change sprite
      
            
          
        }
    }

    IEnumerator ChangeTheDamnSprite()
    {
        if (spriteRenderer.sprite == sprite1) // if the spriteRenderer sprite = sprite1 then change to sprite2
        {
            laughing.Play();
            yield return new WaitForSeconds(0.5f);
            spriteRenderer.sprite = sprite2;
        }


        
 
    }
}
