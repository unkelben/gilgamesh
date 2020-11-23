using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar : MonoBehaviour {
    [SerializeField] float speed;
    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 startScale;
    [SerializeField] Quaternion startRot;

    [SerializeField] GameController gc;

    Animator anim;

    bool start;
    bool drink;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (start) {
            if (!drink) transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy") && start) {
            start = false;
            StartCoroutine(Death(collision.name));
        } else if (collision.name == "Background") {
            drink = true;
            anim.Play("Drink");
            gc.Drink();
        }
    }

    public void Restart() {
        transform.position = startPos;
        transform.localScale = startScale;
        transform.rotation = startRot;
        drink = false;
        start = false;
        anim.Play("Walk");
    }

    public void StartGame() {
        start = true;
    }

    IEnumerator Death(string death) {
        if (death == "Trap") {
            anim.Play("Hurt");
            gc.PlayCloseTrap();
            yield return new WaitForSeconds(2);
            gc.Restart();
        } else if (death == "Hole") {
            gc.PlayFalling();
            for (float i = startScale.x; i > 0; i -= 0.05f) {
                transform.Rotate(Vector3.forward, 20);
                transform.localScale = new Vector3(i, i, i);
                yield return new WaitForSeconds(0.1f);
            }
            gc.Restart();
        }
    }
}
