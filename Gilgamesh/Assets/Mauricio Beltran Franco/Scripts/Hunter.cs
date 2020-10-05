using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour {

    bool start;
    bool returnStart;
    //bool move = true;
    bool dig;
    bool angry;

    [SerializeField] float speed;
    [SerializeField] Vector3 startPos;
    [SerializeField] Transform[] path;
    [SerializeField] Transform[] returnPath;
    public int pathIndex;

    [SerializeField] Hole hole;
    [SerializeField] SpriteRenderer trap;
    [SerializeField] GameController gc;

    // Start is called before the first frame update
    void Start() {
        start = true;
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
                        trap.enabled = true;
                        trap.GetComponent<Collider2D>().enabled = true;
                        pathIndex++;
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
        angry = false;
        transform.position = startPos;
    }


    IEnumerator Dig() {
        for (int i = 0; i < 4; i++) {
            yield return new WaitForSeconds(1);
            hole.Dig();
            //play sound
        }
        pathIndex++;
    }

    IEnumerator Angry() {
        for (float i = 255; i >= 0; i--) {
            GetComponent<SpriteRenderer>().color = new Color(1, i/255, i/255);
            yield return new WaitForSeconds(3f/255);
        }
        pathIndex++;
    }
}
