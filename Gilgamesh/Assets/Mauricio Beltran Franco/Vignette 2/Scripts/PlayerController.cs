using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb;
    Animator anim;

    [SerializeField] float speed;
    Vector2 move;
    bool immobile;

    Crafting station;
    Log pickUp;
    bool grab;

    bool readyAxe;
    bool chop;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (grab) {
            pickUp.transform.position = transform.position + Vector3.up;
        }
    }

    void FixedUpdate() {
        rb.MovePosition((Vector2)transform.position + move * speed * Time.fixedDeltaTime);
    }

    public void Move(InputAction.CallbackContext context) {
        if ((context.performed || context.canceled) && !immobile) {
            move = context.ReadValue<Vector2>();
            anim.SetFloat("Speed", move.magnitude);
        }
    }

    public void Interact(InputAction.CallbackContext context) {
        if (station) {
            if (context.started) {
                if (station is Paint && context.interaction is HoldInteraction) {
                    if (!((Paint)station).IsCrafting() && grab) {
                        if (!pickUp.IsPaint()) {
                            station.Activate();
                            grab = false;
                            ((Paint)station).Insert(pickUp);
                            pickUp = null;
                            anim.Play("Paint");
                        }
                    } else if (((Paint)station).IsCrafting()) {
                        station.Activate();
                        anim.Play("Paint");
                    }
                }
            }

            if (context.canceled) {
                if (station is Paint && context.interaction is HoldInteraction && !grab) {
                    anim.Play("ReadyPaint");
                }
            }

            if (context.performed) {
                if (station is Trees && !(context.interaction is HoldInteraction)) {
                    station.Activate();
                    if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name != "ReadyAxe" && anim.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Chop") {
                        anim.Play("ReadyAxe");
                    } else {
                        if (readyAxe) chop = true;
                        else if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Chop") {
                            anim.Play("Chop");
                            //Play miss sound
                        }
                    }
                }
                if (station is Saw && !(context.interaction is HoldInteraction)) {
                    if (!((Saw)station).IsCrafting() && grab) {
                        if (!pickUp.IsSaw()) {
                            station.Activate();
                            grab = false;
                            ((Saw)station).Insert(pickUp);
                            pickUp = null;
                            anim.Play("ReadySaw");
                        }
                    } else if (((Saw)station).IsCrafting() && !immobile) { //immobile means we're in the Saw animation
                        station.Activate();
                        station.Action();
                        anim.Play("Saw");
                    }
                }
                if (station is Paint && context.interaction is HoldInteraction && anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Paint") {
                    anim.Play("ReadyPaint");
                    station.Action();
                }
            }
        }
    }

    public void Grab(InputAction.CallbackContext context) {
        if (context.performed) {
            if (pickUp) {
                if (grab) {
                    grab = false;
                    pickUp.transform.position = transform.position + Vector3.down;
                    pickUp = null;
                } else grab = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            station = collision.GetComponent<Crafting>();
        }
        if (collision.CompareTag("Target") && !pickUp) {
            pickUp = collision.gameObject.GetComponent<Log>();
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            station.Deactivate();
            station = null;
        }
        if (collision.CompareTag("Target") && !grab) {
            pickUp = null;
        }
    }

    public void ReadyAxe() {
        readyAxe = true;
    }

    public void Chop() {
        readyAxe = false;
        if (chop) {
            chop = false;
            station.Action();
            //Play sound;
        } else {
            //Play miss sound
        }
    }

    public void ResetBool() {
        readyAxe = false;
        chop = false;
    }

    public void SetImmobile(int isImmobile) {
        immobile = (isImmobile == 1);
    }
}
