using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rose.ClawMachine
{
    public class Finger : MonoBehaviour
    {
        [SerializeField] GameObject pivot;

        //ClayCheck Variables
        public bool isTouchingClay { get; set; }

        private void Awake()
        {
            GameObject[] clawmachine = GameObject.FindGameObjectsWithTag("ClawMachine");
            for (int i=0; i < clawmachine.Length; i++)
            {
                Physics.IgnoreCollision(GetComponent<Collider>(), clawmachine[i].GetComponent<Collider>(), true);
            }
        }

        private void Update()
        {
            if (Input.GetKey("space") && isTouchingClay)
            {
                pivot.GetComponent<Hand>().stopPinching = true;
            }
            if (Input.GetKeyUp("space") && isTouchingClay)
            {
                pivot.GetComponent<Hand>().stopPinching = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "PinchLimit")
            {
                pivot.GetComponent<Hand>().stopPinching = true;
            }
        }
    }
}
