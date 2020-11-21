using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letterScript : MonoBehaviour
{
    Vector3 vel = new Vector3(0f, 0f, 0f);
    Vector3 acc = new Vector3(0f, 0f, 0f);
    Vector3 friction = new Vector3(0.1f, 0.1f, 0.1f);
    Vector3 randomOffset;


    float maxVel = 22f;
    float maxVel2 = 2.7f;
    float maxVel2b = 8f;
    float maxVel3 = 12.5f;

    int counter = 0;

    float opacity = 0f;
    public int offset = 0;
    bool offsetted = false;

    public bool frozen = true;
    Vector3 frozenpos;

    public char letter;
    // Start is called before the first frame update
    void Start()
    {
        
        transform.SetParent(GameObject.Find("Canvas").transform);
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(450f, 100f, 0f);
        
        // Debug.Log(gameObject.GetComponent<RectTransform>().position);
        // Vector3 pPos = transform.parent.GetComponent<RectTransform>().position;
        // transform.position = new Vector3(0f, 0f, 0f);
        // gameObject.GetComponent<RectTransform>().position = new Vector3(250f, 0f, 0f) +pPos;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.GetComponent<RectTransform>().anchoredPosition;
        if (offset != 0 && !offsetted)
        {
            pos.x += offset * 8f;
            offsetted = true;
            frozenpos = pos;
        }

        if (pos.x > 150f)
        {
            acc = new Vector3(-0.4f, 0f, 0f);
            opacity = Mathf.Min(opacity + 0.01f, 1f);
        }
        else if(pos.x > -250f)
        {
            opacity = 1f;
            acc = new Vector3(-0.1f, 0f, 0f);
            
            if (!frozen) maxVel = maxVel2b;
            else maxVel = Mathf.Max(maxVel - 1f, maxVel2);
        }
        else if(!frozen)
        {
            acc = new Vector3(-0.3f, 0f, 0f);
            maxVel = maxVel3;
            opacity = Mathf.Max(opacity - 0.1f, 0f);

            if (pos.x < -350f)
            {
                Destroy(gameObject);
            }
        }
        
        

        vel = new Vector3(
            Mathf.Min(Mathf.Max(vel.x + acc.x, -maxVel), maxVel),
            Mathf.Min(Mathf.Max(vel.y + acc.y, -maxVel), maxVel),
            Mathf.Min(Mathf.Max(vel.z + acc.z, -maxVel), maxVel)
            );


        if (frozen && frozenpos.x <= -250f + offset * 8f)
        {
            float count = counter / 100f;
            float range = 10f;
            
            randomOffset = new Vector3(
                2f*range*( Mathf.PerlinNoise(count, 0f) - 0.5f ),
                2f * range * (Mathf.PerlinNoise(count, 1f) - 0.5f),
                0
                );

            counter++;
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(
            frozenpos.x + randomOffset.x,
            frozenpos.y + randomOffset.y,
            frozenpos.z
            );
        }
        else
        {
            frozenpos = pos;
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(
            pos.x + vel.x,
            pos.y + vel.y,
            pos.z
            );
        }

        

        Color color = this.GetComponent<UnityEngine.UI.Text>().color;
        color.a = opacity;
        this.GetComponent<UnityEngine.UI.Text>().color = color;
    }
}
