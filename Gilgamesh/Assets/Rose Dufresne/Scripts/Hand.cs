using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.ClawMachine
{
    public class Hand : MonoBehaviour
    {
        [SerializeField] float pinchSpeed;
        [SerializeField] bool isRight;
        private float rotationAngleZ;

        private float originalAngleZ;
        public bool stopPinching { get; set; }

        // Start is called before the first frame update
        void Start()
        {
            originalAngleZ = transform.rotation.z;
            stopPinching = false;
        }

        // Update is called once per frame
        void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (!stopPinching)
            {
                if (Input.GetMouseButton(0))
                {
                    Pinch();
                }
                else
                {
                    UnPinch();
                }
            }

            if (Input.GetMouseButtonUp(0) && stopPinching)
            {
                UnPinch();
                stopPinching = false;
            }
        }

        private void Pinch()
        {
            rotationAngleZ = isRight ? -pinchSpeed : pinchSpeed;
            transform.Rotate(new Vector3(0, 0, rotationAngleZ * Time.deltaTime), Space.Self);
        }

        private void UnPinch()
        {
            if (isRight)
            {
                if (transform.rotation.z <= originalAngleZ)
                {
                    rotationAngleZ = pinchSpeed;
                    transform.Rotate(new Vector3(0, 0, rotationAngleZ * Time.deltaTime), Space.Self);
                }
            }
            else
            {
                if (transform.rotation.z >= originalAngleZ)
                {
                    rotationAngleZ = -pinchSpeed;
                    transform.Rotate(new Vector3(0, 0, rotationAngleZ * Time.deltaTime), Space.Self);
                }
            }
        }
    }
}