using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using CharacterCreator2D;

public class ShamhatMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Flowchart flowchart;
    [SerializeField] CharacterViewer shamhat;
    Rigidbody2D shamhatRigidBody;
    Animator shamhatAnimator;


    bool dialogueFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        shamhatRigidBody = GetComponent<Rigidbody2D>();
        shamhatAnimator = GetComponent<Animator>();
    }

    private void Move()
    {
     
        Vector2 shamhatVel = new Vector2(-1 * speed, shamhatRigidBody.velocity.y);

        shamhatRigidBody.velocity = shamhatVel;
        

        shamhatAnimator.SetBool("Walking", true);

    }

    private void Run()
    {
        transform.localScale = new Vector2(0.5f, 0.5f);
        shamhatAnimator.SetBool("Running", true);
        Vector2 shamhatVel = new Vector2(1 * speed, shamhatRigidBody.velocity.y);

        shamhatRigidBody.velocity = shamhatVel;

    }

    void Talk()
    {
        shamhat.Emote("Talk",1f);
    }

    void Blink()
    {
        shamhat.Emote("Blink", 2f);
    }
}
