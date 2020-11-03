using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb;

    [SerializeField] float speed;
    Vector2 move;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
    }

    void FixedUpdate() {
        rb.MovePosition((Vector2)transform.position + move * speed * Time.fixedDeltaTime);
    }

    public void Move(InputAction.CallbackContext context) {
        if (context.performed || context.canceled) {
            move = context.ReadValue<Vector2>();
            print(move);
        }
    }
}
