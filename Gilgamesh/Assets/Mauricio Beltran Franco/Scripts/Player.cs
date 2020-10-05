using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] Vector3 startPos;
    [SerializeField] Transform trap;
    [SerializeField] Transform shovel;
    [SerializeField] Transform pond;
    [SerializeField] Hole hole;

    [SerializeField] float speed;

    [SerializeField] GameController gc;

    RaycastHit2D hit;

    bool start;
    bool drink;
    bool goDrink;
    bool disarm;
    bool shovelFill;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (start) {
            if (Input.GetMouseButtonDown(0)) {
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, LayerMask.GetMask("player"));
                if (hit) {
                    switch (hit.collider.name) {
                        case "Trap":
                            disarm = true;
                            shovelFill = false;
                            break;
                        case "Shovel":
                            shovelFill = true;
                            disarm = false;
                            break;
                        case "Pond":
                            if (drink) goDrink = true;
                            break;
                    }
                }
            }
        }
        if (disarm) {
            transform.Translate((trap.position - transform.position).normalized * speed * Time.deltaTime);
            if ((trap.position - transform.position).magnitude <= 0.1f) {
                disarm = false;
                trap.GetComponent<Collider2D>().enabled = false;
                trap.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        if (shovelFill) {
            transform.Translate((shovel.position - transform.position).normalized * speed * Time.deltaTime);
            if ((shovel.position - transform.position).magnitude <= 0.1f) {
                shovelFill = false;
                hole.Fill();
            }
        }
        if (goDrink) {
            transform.Translate((pond.position - transform.position).normalized * speed * Time.deltaTime);
            if ((pond.position - transform.position).magnitude <= 0.1f) {
                goDrink = false;
                start = false;
                gc.EndDay();
            }
        }
    }

    public void StartGame() {
        start = true;
    }

    public void Restart() {
        transform.position = startPos;
        start = false;
        drink = false;
        goDrink = false;
        disarm = false;
        shovelFill = false;
    }

    public void Drink() {
        drink = true;
    }
}
