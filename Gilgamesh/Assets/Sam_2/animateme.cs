using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateme : MonoBehaviour
{

    public List<Sprite> sprites;
    public bool running = true;

    int counter = 0;
    public int updatePeriod = 100;
    int animFrame = 0;

    SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (running && counter % updatePeriod == 0)
        {
            rend.sprite = sprites[animFrame];
            animFrame = (animFrame + 1) % sprites.Count;
            
        }
        counter++;
    }
}
