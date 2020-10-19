using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hunter : MonoBehaviour {

    bool start;
    bool returnStart;
    bool dig;
    bool trapping;
    bool angry;

    [SerializeField] float speed;
    [SerializeField] Vector3 startPos;
    [SerializeField] Transform[] path;
    [SerializeField] Transform[] returnPath;
    public int pathIndex;

    [SerializeField] Hole hole;
    [SerializeField] SpriteRenderer trap;
    [SerializeField] GameController gc;

    string[] quotes = { "What!? My food!!", "AGAIN!?!?", "That's it! I'm telling father!" };
    [SerializeField] TextMeshPro text;
    int textIndex;

    Animator anim;

    // Start is called before the first frame update
    void Start() {
        start = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (start) {
            if (pathIndex < path.Length) {
                transform.Translate((path[pathIndex].position - transform.position).normalized * speed * Time.deltaTime);
                if ((transform.position - path[pathIndex].position).magnitude < 0.1f) {
                    if (pathIndex == 1) {
                        if (!dig) {
                            StartCoroutine("Dig");
                            dig = true;
                        }
                    } else if (pathIndex == 2) {
                        if (!trapping){
                            StartCoroutine("Trap");
                            trapping = true;
                            trap.enabled = true;
                            trap.GetComponent<Collider2D>().enabled = true;
                        }
                    } else pathIndex++;
                }
            } else {
                start = false;
                gc.StartBoar();
            }
        } else if (returnStart) {
            if (pathIndex < returnPath.Length) {
                transform.Translate((returnPath[pathIndex].position - transform.position).normalized * speed * Time.deltaTime);
                if ((transform.position - returnPath[pathIndex].position).magnitude < 0.1f) {
                    if (pathIndex == 1) {
                        if (!angry) {
                            StartCoroutine("Angry");
                            angry = true;
                        }
                    } else pathIndex++;
                }
            } else {
                returnStart = false;
                gc.NewDay();
            }
        }
    }

    public void StartGame() {

    }

    public void Return() {
        returnStart = true;
        pathIndex = 0;
    }

    public void Restart() {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        hole.Restart();
        trap.enabled = false;
        trap.GetComponent<Collider2D>().enabled = false;
        pathIndex = 0;
        start = true;
        returnStart = false;
        dig = false;
        trapping = false;
        angry = false;
        transform.position = startPos;
    }


    IEnumerator Dig() {
        for (int i = 0; i < 4; i++) {
            anim.Play("Interact");
            gc.PlayShovel();
            yield return new WaitForSeconds(1);
            hole.Dig();
        }
        pathIndex++;
        anim.Play("Walk");
    }

    IEnumerator Trap() {
        anim.Play("Interact");
        gc.PlayPlaceTrap();
        yield return new WaitForSeconds(1);
        pathIndex++;
        anim.Play("Walk");
    }

    IEnumerator Angry() {
        anim.Play("Idle");
        gc.PlayMad();
        StartCoroutine("Text");
        for (float i = 255; i >= 0; i--) {
            GetComponent<SpriteRenderer>().color = new Color(1, i / 255, i / 255);
            yield return new WaitForSeconds(3f / 255);
        }
        pathIndex++;
        anim.Play("Walk");
    }

    IEnumerator Text() {
        text.enabled = true;
        text.text = quotes[textIndex++];
        yield return new WaitForSeconds(3);
        text.enabled = false;
    }
}
