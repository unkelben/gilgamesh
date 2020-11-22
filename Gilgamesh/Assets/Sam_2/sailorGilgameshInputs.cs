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
    public int height = 0;
    public float sailPower = 0f;

    public bool upPressed = false;
    public bool downPressed = false;

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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            changed = true;
            height = Mathf.RoundToInt(Mathf.Min(height + 1f, sprites.Count-1f));
            upPressed = true;
           // Debug.Log("W! height: " + height);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            changed = true;
            height = Mathf.RoundToInt(Mathf.Max(height - 1f, 0f));
            downPressed = true;
            //Debug.Log("S! height: " + height);
        }

        if (changed)
        {
            // Debug.Log("update spriite " + height);
            updateSprites();
        }

        byte redval = (byte)(255f-sailPower * 5f);
        sails[height].GetComponent<SpriteRenderer>().color = new Color32(255, redval, redval, 255);
        sailPower = Mathf.Min(Mathf.Max(sailPower - 0.2f, 0f), 45f);


    }

    void updateSprites()
    {
        rend.sprite = sprites[height];
        transform.localPosition = new Vector3(displacement[height].x, displacement[height].y, transform.position.z);

        foreach (GameObject sail in sails){
            sail.active = false;
        }

        sails[height].active = true;
    }
}
