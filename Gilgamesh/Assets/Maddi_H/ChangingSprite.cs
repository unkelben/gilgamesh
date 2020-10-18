using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingSprite : MonoBehaviour
{

    public int breadValue = 1;
    private Sprite PackForest01_5,PackForest01_8;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void UpdateSprite()
    {
        if(breadValue == 7) 
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = PackForest01_8;
        }
    }
}
