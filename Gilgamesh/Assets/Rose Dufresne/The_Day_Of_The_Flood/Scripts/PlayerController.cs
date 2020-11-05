using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rose.Characters
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float rotationSpeed;

        private Rigidbody2D rb;

        private Vector2 inputVector;
        private Vector2 moveAmount;
        private Vector2 smoothMoveVelocity;
        private bool isMoving;

        public List<GameObject> surroundingNpcs { get; set; }

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = inputVector * speed * Time.deltaTime;
        }

        void Start()
        {
            surroundingNpcs = new List<GameObject>();
            isMoving = false;
        }

        private void FixedUpdate()
        {
            Movement();
        }

        void Update()
        {
            HandleInput();
            FaceDirection();
        }

        void HandleInput()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            
            isMoving = horizontal != 0 | vertical != 0;

            inputVector = new Vector2(horizontal, vertical);
            moveAmount = Vector2.SmoothDamp(moveAmount, inputVector, ref smoothMoveVelocity, 0.15f);
        }

        void Movement()
        {
            if (isMoving)
                rb.velocity = inputVector * speed * Time.deltaTime;
            else
                rb.velocity = new Vector2(0, 0);
        }

        void FaceDirection()
        {
            if (isMoving)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, moveAmount), rotationSpeed * Time.deltaTime);
        }
    }
}
