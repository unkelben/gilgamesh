using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Rose.Utilities
{
    using Rose.Characters;

    public class CameraController : MonoBehaviour
    {
        GameObject target;
        [SerializeField] float height; //above target
        [SerializeField] float distance; //behind or in front of target
        [SerializeField] float smoothingSpeed;

        private Vector3 refVelocity;
        private float refSpeed;
        private float fixedLookAtRotation;

        float currentHeight;

        private Camera playerCamera;

        void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player");
            playerCamera = GetComponent<Camera>();
            currentHeight = this.GetComponent<Camera>().orthographicSize;
        }

        void Update()
        {
            HandleCamera();
        }

        protected virtual void HandleCamera()
        {
            float mainHeight = 2f * Camera.main.orthographicSize;
            float mainWidth = mainHeight * Camera.main.aspect;

            float height = 2f * this.GetComponent<Camera>().orthographicSize;
            float width = height * this.GetComponent<Camera>().aspect;

            //move camera position to follow target
            float xPosition = 0;
            float yPosition = 0;

            Vector3 targetPosition = new Vector3(xPosition, yPosition, transform.position.z);

            if (!target)
            {
                playerCamera.orthographicSize = Mathf.SmoothDamp(height / 2, mainHeight / 2, ref refSpeed, 1);
                smoothingSpeed = 1;
            }
            else
            {
                if ((target.transform.position.x - width / 2 <= -mainWidth / 2) || (target.transform.position.x + width / 2 >= mainWidth / 2))
                {
                    xPosition = transform.position.x;
                }
                else
                {
                    xPosition = target.transform.position.x;
                }
                if ((target.transform.position.y - height / 2 <= -mainHeight / 2) || (target.transform.position.y + height / 2 >= mainHeight / 2))
                {
                    yPosition = transform.position.y;
                }
                else
                {
                    yPosition = target.transform.position.y;
                }

                targetPosition = new Vector3(xPosition, yPosition, transform.position.z);

                //zoom in/out
                if (target.GetComponent<PlayerController>().inBoat)
                {
                    playerCamera.orthographicSize = Mathf.SmoothDamp(height / 2, mainHeight / 2, ref refSpeed, 1);
                }
                else
                {
                    playerCamera.orthographicSize = Mathf.SmoothDamp(height / 2, currentHeight, ref refSpeed, 1);
                }
            }

            Vector3 finalPosition = targetPosition;

            if ((int)height / 2 == currentHeight)
            {
                transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, smoothingSpeed);
            }
            else
                if (height / 2 - 40 >= 0)
                transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, (height / 2 - 40) / 20);
            //transform.LookAt(Vector3.forward, target.position);
        }
    }
}
