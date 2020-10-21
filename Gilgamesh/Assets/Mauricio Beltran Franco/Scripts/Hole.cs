using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {
    [SerializeField] Sprite[] sprites;
    [SerializeField] GameController gc;
    int spriteIndex;

    SpriteRenderer sprRend;

    // Start is called before the first frame update
    void Start() {
        sprRend = GetComponent<SpriteRenderer>();
        spriteIndex = sprites.Length - 1;
    }

    // Update is called once per frame
    void Update() {

    }

    public void Fill() {
        if (spriteIndex < sprites.Length - 1) sprRend.sprite = sprites[++spriteIndex];
        if (spriteIndex == sprites.Length - 1) {
            GetComponent<Collider2D>().enabled = false;
            gc.DisableShovel();
        }
    }

    public void Dig() {
        GetComponent<Collider2D>().enabled = true;
        sprRend.sprite = sprites[--spriteIndex];
    }

    public void Restart() {
        spriteIndex = sprites.Length - 1;
        sprRend.sprite = sprites[spriteIndex];
        GetComponent<Collider2D>().enabled = false;
    }
}
