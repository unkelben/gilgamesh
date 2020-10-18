using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCreator2D;


public class ShepherdEmotions : MonoBehaviour
{
    [SerializeField] CharacterViewer shepherd;
    [SerializeField] float speed;

    Rigidbody2D shepherdRigidBody;
    Animator shepherdAnimator;

    void Start()
    {
        shepherdRigidBody = GetComponent<Rigidbody2D>();
        shepherdAnimator = GetComponent<Animator>();
    }

    private void Run()
    {
        
        shepherdAnimator.SetBool("Running", true);
        Vector2 shepherdVel = new Vector2(1 * speed, shepherdRigidBody.velocity.y);

        shepherdRigidBody.velocity = shepherdVel;

    }

    void Happy()
    {
        shepherd.Emote("Hurt");
    }

    void Blink()
    {
        shepherd.Emote("Blink", 1f);
    }

    void Angry()
    {
        shepherd.Emote("Angry");
    }

    void AngryTalk()
    {
        shepherd.Emote("Angry Talk", 2f);
    }

    void Talk()
    {
        shepherd.Emote("Talk", 1f);
    }

    void DefaultEmotion()
    {
        shepherd.ResetEmote();
    }
}
