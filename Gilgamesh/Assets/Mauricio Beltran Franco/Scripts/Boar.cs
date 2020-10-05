using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar : MonoBehaviour {
    [SerializeField] float speed;
    [SerializeField] Vector3 startPos;

    [SerializeField] GameController gc;

    bool start;
    bool drink;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (start) {
            if (!drink) transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            gc.Restart();
        } else if (collision.name == "Pond") {
            drink = true;
            gc.Drink();
        }
    }

    public void Restart() {
        transform.position = startPos;
        drink = false;
        start = false;
    }

    public void StartGame() {
        start = true;
    }
}
