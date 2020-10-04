using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.ClawMachine
{
    public class Finger : MonoBehaviour
    {
        [SerializeField] GameObject pivot;

        //ClayCheck Variables
        [SerializeField] LayerMask whatIsClay;
        [SerializeField] private Vector3 clayBoxExtents = new Vector3(0.5f,0.5f,0.5f);
        private List<ColliderCheck> clayCheckList;
        public bool isTouchingClay { get; set; }
        private GameObject clay;

        private void Awake()
        {
            GameObject[] clawmachine = GameObject.FindGameObjectsWithTag("ClawMachine");
            for (int i=0; i < clawmachine.Length; i++)
            {
                Physics.IgnoreCollision(GetComponent<Collider>(), clawmachine[i].GetComponent<Collider>(), true);
            }

            // Obtain clay check components and store in list
            clayCheckList = new List<ColliderCheck>();
            ColliderCheck[] clayCheckArray = transform.GetComponentsInChildren<ColliderCheck>();
            foreach (ColliderCheck g in clayCheckArray)
            {
                clayCheckList.Add(g);
            }
        }

        private void Update()
        {
            if (Input.GetMouseButton(0) && isTouchingClay)
            {
                pivot.GetComponent<Hand>().stopPinching = true;
            }
            if (Input.GetMouseButton(1) && isTouchingClay)
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
