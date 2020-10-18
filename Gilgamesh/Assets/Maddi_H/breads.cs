using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breads : MonoBehaviour
{
    private Sprite PackForest01_5,PackForest01_8;
    private SpriteRenderer render;
    public int breadValue = 1;

//private void Start()
//    {
  //      render = GetComponent<SpriteRenderer>();
       // PackForest01_5 = Resources.Load<Sprite>("PackForest01_5");
        //PackForest01_8 = Resources.Load<Sprite>("PackForest01_8");
    //    render.sprite = PackForest01_5;
    //}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           ScoreManager.instance.ChangeScore(breadValue);
           if(breadValue.Equals(7))
           {
                 render.sprite = PackForest01_8;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = PackForest01_8;
           }
        
        }
    }

}
