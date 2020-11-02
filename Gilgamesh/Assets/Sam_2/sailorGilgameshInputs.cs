using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sailorGilgameshInputs : MonoBehaviour
{
    public List<Sprite> sprites;
    public List<Vector2> displacement;
    public List<GameObject> sails;
    public List<Vector2> sailPositions;
    SpriteRenderer rend;
    int height = 0;

    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
        updateSprites();
    }

    // Update is called once per frame
    void Update()
    {
        bool changed = false;
        if (Input.GetKeyDown("w"))
        {
            changed = true;
            height = Mathf.RoundToInt(Mathf.Min(height + 1f, sprites.Count-1f));
           // Debug.Log("W! height: " + height);
        }
        else if (Input.GetKeyDown("s"))
        {
            changed = true;
            height = Mathf.RoundToInt(Mathf.Max(height - 1f, 0f));
            //Debug.Log("S! height: " + height);
        }

        if (changed)
        {
            // Debug.Log("update spriite " + height);
            updateSprites();
        }

    }

    void updateSprites()
    {
        rend.sprite = sprites[height];
        transform.position = new Vector3(displacement[height].x, displacement[height].y, transform.position.z);

        foreach (GameObject sail in sails){
            sail.active = false;
        }

        sails[height].active = true;
    }
}
