using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using CharacterCreator2D;

public class EnkiduInside : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Flowchart flowchart;
    [SerializeField] CharacterViewer enkidu;
    [SerializeField] GameObject axe;
    Rigidbody2D enkiduRigidBody;
    Animator enkiduAnimator;
    bool allowMovement = false;

    public Color weaponColor1;
    public Color weaponColor2;
    public Color weaponColor3;



    void Start()
    {
        enkiduRigidBody = GetComponent<Rigidbody2D>();
        enkiduAnimator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

        allowMovement = flowchart.GetBooleanVariable("allowMovement");
        
         Move();
        
        
    }

    private void Move()
    {
        if (allowMovement == true)
        {
            float controlDir = Input.GetAxis("Horizontal");
            Vector2 enkiduVel = new Vector2(controlDir * speed, enkiduRigidBody.velocity.y);

            enkiduRigidBody.velocity = enkiduVel;

            bool playerIsMoving = Mathf.Abs(enkiduRigidBody.velocity.x) > Mathf.Epsilon;

            enkiduAnimator.SetBool("Walking", playerIsMoving);


            Flip();
        } else
        {
            Vector2 enkiduVel = new Vector2(0f,0f);

            enkiduRigidBody.velocity = enkiduVel;
            enkiduAnimator.SetBool("Walking", false);
        }
    }

    private void Flip()
    {
        bool playerIsMoving = Mathf.Abs(enkiduRigidBody.velocity.x) > Mathf.Epsilon;

        if (playerIsMoving)
        {
            transform.localScale = new Vector2 (Mathf.Sign(enkiduRigidBody.velocity.x) / 2, 0.5f);
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Meet Trigger")
        {
            flowchart.ExecuteBlock("Meet Dialogue");
        }

        if (other.tag == "Axe")
        {
            Debug.Log("Its Triggering");
            enkidu.EquipPart(SlotCategory.OffHand, "Axe 01");
            enkidu.SetPartColor(SlotCategory.OffHand, weaponColor1, weaponColor2, weaponColor3);
            axe.SetActive(false);
        }

    }
}
