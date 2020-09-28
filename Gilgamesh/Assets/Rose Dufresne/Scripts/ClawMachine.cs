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

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            HandleInput();
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void HandleInput()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            isMoving = horizontal != 0 || vertical != 0;

            inputVector = new Vector3(horizontal, vertical, 0f).normalized;
            moveAmount = Vector3.SmoothDamp(moveAmount, inputVector, ref smoothMoveVelocity, 0.15f);
        }

        private void Movement()
        {
            rb.velocity = transform.TransformDirection(moveAmount) * speed * Time.deltaTime;
        }
    }
}
