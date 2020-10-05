using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Game.ClawMachine;

namespace Game.Clay
{
    public class Clay : MonoBehaviour
    {
        private bool touchingClay;
        private List<GameObject> finger;
        [SerializeField] float weight;

        public float clayWeight;

        private void Start()
        {
            clayWeight = weight;
            finger = new List<GameObject>();
            touchingClay = false;
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0) && touchingClay)
            {
                touchingClay = false;
                foreach (GameObject f in finger)
                {
                    f.GetComponentInParent<Finger>().isTouchingClay = touchingClay;
                }
                finger.Clear();
                gameObject.transform.parent = transform.parent.parent.parent;
                gameObject.transform.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.transform.GetComponent<Rigidbody>().useGravity = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "FingerTip" && finger.Count < 2 && Input.GetMouseButton(0))
            {
                touchingClay = true;
                finger.Add(other.gameObject);
                other.GetComponentInParent<Finger>().isTouchingClay = touchingClay;
                gameObject.transform.parent = other.transform.parent.parent;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }
}