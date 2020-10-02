using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.ClawMachine
{
    public class Finger : MonoBehaviour
    {
        [SerializeField] GameObject hand;

        

        private void Start()
        {
            
        }

        private void FixedUpdate()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "PinchLimit")
            {
                hand.GetComponent<Hand>().stopPinching = true;
            }
        }

        
    }
}
