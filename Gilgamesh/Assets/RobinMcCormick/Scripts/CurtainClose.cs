using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainClose : MonoBehaviour
{

    public bool isMouseOverCurtain = false;
    public bool interactedWithCurtain = false;

    public ChangeBackground cB;

    public SpriteRenderer spriteR;
    public Sprite newSprite;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactedWithCurtain == false && isMouseOverCurtain == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Interacted with curtain.");
                spriteR.sprite = newSprite;
                spriteR.transform.position = new Vector3(-4.18f, 2.35f, 0);
                spriteR.transform.localScale = new Vector3(0.5293848f, 0.5293848f, 0.5293848f);
                source.Play();
                cB.interactionAmount = cB.interactionAmount += 1;

                interactedWithCurtain = true;
            }
        }
    }

    void OnMouseEnter()
    {
        if (interactedWithCurtain == false)
        {
            Debug.Log("on curtain");
            spriteR.color = Color.gray;
            isMouseOverCurtain = true;
        }

    }

    void OnMouseExit()
    {
        Debug.Log("not on curtain");
        spriteR.color = Color.white;
        isMouseOverCurtain = false;
    }
}
