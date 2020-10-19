using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Rose.ClawMachine;

namespace Rose.Clay
{
    public class Clay : MonoBehaviour
    {
        private bool touchingClay;
        private bool undersideTouched;
        public bool isInHand { get; set; }
        private List<GameObject> finger;
        [SerializeField] public float weight;

        private void Start()
        {
            transform.localScale = (transform.localScale) * weight/10f;
            finger = new List<GameObject>();
            touchingClay = false;
        }

        private void Update()
        {
            if (Input.GetKeyUp("space") && touchingClay)
            {
                touchingClay = false;
                foreach (GameObject f in finger)
                {
                    f.GetComponentInParent<Finger>().isTouchingClay = touchingClay;
                    f.tag = "FingerTip";
                }
                finger.Clear();
                gameObject.transform.parent = transform.parent.parent.parent;
                gameObject.transform.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.transform.GetComponent<Rigidbody>().useGravity = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.tag == "Underside")
            {
                undersideTouched = true;
            }

            if (other.tag == "FingerTip" && finger.Count < 3 && Input.GetKey("space") && !undersideTouched)
            {
                other.tag = "Untagged";
                touchingClay = true;
                finger.Add(other.gameObject);
                gameObject.transform.parent = other.transform.parent.parent;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.GetComponent<Rigidbody>().isKinematic = true;

                if(finger.Count > 1)
                {
                    foreach (GameObject f in finger)
                    {
                        f.GetComponentInParent<Finger>().isTouchingClay = touchingClay;
                    }
                }
            }

            if (other.tag == "InsideHand")
            {
                isInHand = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Underside")
            {
                undersideTouched = false;
            }

            if (other.tag == "InsideHand")
            {
                isInHand = false;
            }
        }
    }
}