using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.ClawMachine
{
    public class ClawMachine : MonoBehaviour
    {

        [SerializeField] float speed;
        private Vector3 moveAmount;
        private Vector3 smoothMoveVelocity;
        private Vector3 inputVector;
        private bool isMoving;

        Rigidbody rb;

        //GroundCheck Variables
        [SerializeField] LayerMask mWhatIsGround;
        [SerializeField] private float kGroundCheckRadius = 0.1f;
        private List<ColliderCheck> mGroundCheckList;
        private bool mGrounded;
        private GameObject[] fingers;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();

            // Obtain ground check components and store in list
            mGroundCheckList = new List<ColliderCheck>();
            ColliderCheck[] groundChecksArray = transform.GetComponentsInChildren<ColliderCheck>();
            foreach (ColliderCheck g in groundChecksArray)
            {
                mGroundCheckList.Add(g);
            }

            GameObject[] ignore = GameObject.FindGameObjectsWithTag("ClawMachine");
            for (int i = 0; i < ignore.Length; i++)
            {
                for (int j=0; j< gameObject.GetComponentsInChildren<Collider>().Length; j++)
                Physics.IgnoreCollision(gameObject.GetComponentsInChildren<Collider>()[j], ignore[i].GetComponent<Collider>(), true);
            }
        }

        private void Start()
        {
            Finger[] fingerArray = FindObjectsOfType<Finger>();
            fingers = new GameObject[fingerArray.Length];
            for (int i=0; i < fingerArray.Length; i++)
            {
                fingers[i] = fingerArray[i].gameObject;
            }

            mGrounded = false;
        }

        private void Update()
        {
            HandleInput();
        }

        private void FixedUpdate()
        {
            CheckGrounded();
            Movement();
        }

        private void HandleInput()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            if (mGrounded)
            {
                vertical = vertical < 0 ? vertical = 0 : vertical;
            }

            isMoving = horizontal != 0 || vertical != 0;

            inputVector = new Vector3(horizontal, vertical, 0f).normalized;
            moveAmount = mGrounded ? inputVector : Vector3.SmoothDamp(moveAmount, inputVector, ref smoothMoveVelocity, 0.15f);
        }

        private void Movement()
        {
            rb.velocity = transform.TransformDirection(moveAmount) * speed * Time.deltaTime;
        }

        //IsGrounded function that performs the logic and returns a boolean - true if the player is on the ground, false otherwise.
        private void CheckGrounded()
        {
            foreach (ColliderCheck g in mGroundCheckList)
            {
                for (int i = 0; i < fingers.Length; i++)
                {
                    if (g.CheckGrounded(kGroundCheckRadius, mWhatIsGround, fingers[i]))
                    {
                        mGrounded = true;
                        return;
                    }
                }
            }
            mGrounded = false;
        }
    }
}
