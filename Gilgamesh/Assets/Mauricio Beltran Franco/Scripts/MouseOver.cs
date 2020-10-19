using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour {

    RaycastHit2D hit;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] bool pond;

    // Update is called once per frame
    void Update() {
        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, LayerMask.GetMask("Water"));
        if (hit) {
            if (hit.collider.gameObject == this.gameObject) {
                if (!pond) sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.7f);
                else sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.3f);
            }
        } else {
            if (!pond) sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
            else sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);
        }
    }

    private void OnDisable() {
        if (!pond) sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        else sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);
    }
}
