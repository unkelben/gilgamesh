using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingSprite : MonoBehaviour
{
    private SpriteRenderer render;
    public int breadValue = 1;
    private Sprite PackForest01_5,PackForest01_8;

    // Start is called before the first frame update
    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
        PackForest01_5 = Resources.Load<Sprite>("PackForest01_5");
        PackForest01_8 = Resources.Load<Sprite>("PackForest01_8");
        render.sprite = PackForest01_5;
    }

    // Update is called once per frame
    private void UpdateSprite()
    {
        if(breadValue == 7) 
        {

            render.sprite = PackForest01_8;

           // this.gameObject.GetComponent<SpriteRenderer>().sprite = PackForest01_8;
        }
        
    }
}
