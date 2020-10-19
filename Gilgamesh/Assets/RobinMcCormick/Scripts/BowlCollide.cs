using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlCollide : MonoBehaviour
{
    public MouseOverRag mouseOverRag;

    private AudioSource source;

    public bool dipBowl = false;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (dipBowl == false)
        {
            if (other.gameObject.CompareTag("Rag"))
            {
                Debug.Log("Rag touched Bowl");
                mouseOverRag.isWet = true;
                source.Play();
                dipBowl = true;
            }
        }

    }
}
