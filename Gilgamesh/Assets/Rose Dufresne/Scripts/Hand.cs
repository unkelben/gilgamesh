using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rose.ClawMachine
{
    public class Hand : MonoBehaviour
    {
        [SerializeField] float pinchSpeed;
        [SerializeField] bool isRight;
        public float rotationAngleZ;

        private float originalAngleZ;
        public bool stopPinching { get; set; }

        [SerializeField] GameObject hand;
        private SkinnedMeshRenderer blendshapes;
        public Vector3 initialRotationZ;

        // Start is called before the first frame update
        void Start()
        {
            originalAngleZ = transform.rotation.z;
            stopPinching = false;

            blendshapes = hand.GetComponent<SkinnedMeshRenderer>();
            blendshapes.SetBlendShapeWeight(0, 0); //thumb
            blendshapes.SetBlendShapeWeight(1, 0); //finger

            initialRotationZ = transform.up;
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
            if (isRight)
            {
                blendshapes.SetBlendShapeWeight(1, (Vector3.Angle(initialRotationZ, transform.up) * 10f));
            }
            else
            {

                blendshapes.SetBlendShapeWeight(0, (Vector3.Angle(initialRotationZ, transform.up) * 10f));
            }
        }

        private void UnPinch()
        {
            if (isRight)
            {
                if (transform.rotation.z <= originalAngleZ)
                {
                    rotationAngleZ = pinchSpeed;
                    transform.Rotate(new Vector3(0, 0, rotationAngleZ * Time.deltaTime), Space.Self);
                    blendshapes.SetBlendShapeWeight(1, Mathf.Clamp((Mathf.Abs((int)Vector3.Angle(initialRotationZ, transform.up))) * 10, 0, 100));
                }
            }
            else
            {
                if (transform.rotation.z >= originalAngleZ)
                {
                    rotationAngleZ = -pinchSpeed;
                    transform.Rotate(new Vector3(0, 0, rotationAngleZ * Time.deltaTime), Space.Self);
                    blendshapes.SetBlendShapeWeight(0, Mathf.Clamp((Mathf.Abs((int)Vector3.Angle(initialRotationZ, transform.up))) * 10, 0, 100));
                }
            }
        }
    }
}