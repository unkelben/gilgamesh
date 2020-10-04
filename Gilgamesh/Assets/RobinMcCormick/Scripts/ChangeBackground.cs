using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite enkidu_bg1;
    public Sprite enkidu_bg2;
    public Sprite enkidu_bg3;
    public Sprite enkidu_bg4;
    public bool bg1Active = true;
    public bool bg2Active = false;
    public bool bg3Active = false;
    public bool bg4Active = false;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer bg1 = enkidu_bg1.Sprite.GetComponent<SpriteRenderer>();
        bg1.enabled = true;

       // MeshRenderer mr1 = Maze1.gameObject.GetComponent<MeshRenderer>();
       // mr1.enabled = true;
       // Collider cr1 = Maze1.gameObject.GetComponent<Collider>();
       // cr1.enabled = true;

        bg1Active = true;
        bg2Active = false;
        bg3Active = false;
        bg4Active = false;
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
