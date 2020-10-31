

#define hello 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour {
    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 movePos;
    [SerializeField] Transform trap;
    [SerializeField] Transform shovel;
    [SerializeField] Transform pond;
    [SerializeField] Hole hole;

    [SerializeField] float speed;

    [SerializeField] GameController gc;

    RaycastHit2D hit;

    Animator anim;

    string[] quotes = { "Oh no! Need to help animal friend!", "Friend safe! I'm thirsty!", "Must help again!", "Safe! Need to drink!", "One more time!", "Water!"};
    [SerializeField] TextMeshPro text;
    int textIndex;

    bool walk;
    bool start;
    bool drink;
    bool goDrink;
    bool disarm;
    bool shovelFill;

    public float shovelTimer = 1;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (shovelTimer < 1) shovelTimer += Time.deltaTime;

        if (walk) {
            anim.Play("Walk");
            transform.Translate((movePos - transform.position).normalized * speed * Time.deltaTime);
            if ((movePos - transform.position).magnitude < 0.1f) {
                start = true;
                walk = false;
                StartCoroutine("Text");
                anim.Play("Idle");
            }
        }

        if (start) {
            if (Input.GetMouseButtonDown(0)) {
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, LayerMask.GetMask("Water"));
                if (hit) {
                    switch (hit.collider.name) {
                        case "Trap":
                            disarm = true;
                            shovelFill = false;
                            break;
                        case "Shovel":
                            if (shovelTimer >= 1) {
                                shovelFill = true;
                                disarm = false;
                            }
                            break;
                        case "Background":
                            if (drink) goDrink = true;
                            break;
                    }
                }
            }
        }
        if (disarm) {
            anim.Play("Walk");
            transform.Translate((trap.position - transform.position).normalized * speed * Time.deltaTime);
            if ((trap.position - transform.position).magnitude <= 0.1f) {
                disarm = false;
                anim.Play("Interact");
                gc.PlayCloseTrap();
                trap.GetComponent<Collider2D>().enabled = false;
                trap.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        if (shovelFill) {
            anim.Play("Walk");
            transform.Translate((shovel.position - transform.position).normalized * speed * Time.deltaTime);
            if ((shovel.position - transform.position).magnitude <= 0.1f) {
                shovelFill = false;
                anim.Play("Interact");
                gc.PlayShovel();
                hole.Fill();
                shovelTimer = 0;
            }
        }
        if (goDrink) {
            anim.Play("Walk");
            transform.Translate((pond.position - transform.position).normalized * speed * Time.deltaTime);
            if ((pond.position - transform.position).magnitude <= 0.1f) {
                goDrink = false;
                start = false;
                anim.Play("Interact");
                gc.PlayDrink();
                gc.EndDay();
            }
        }
    }

    public void StartGame() {
        walk = true;
    }

    public void Restart() {
        if (textIndex % 2 != 0) textIndex--;
        transform.position = startPos;
        start = false;
        drink = false;
        goDrink = false;
        disarm = false;
        shovelFill = false;
    }

    public void Drink() {
        drink = true;
        StartCoroutine("Text");
    }

    IEnumerator Text() {
        text.enabled = true;
        text.text = quotes[textIndex++];
        yield return new WaitForSeconds(3);
        text.enabled = false;
    }
}
