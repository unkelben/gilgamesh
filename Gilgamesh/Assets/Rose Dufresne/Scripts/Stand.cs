using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rose.Balance
{
    public class Stand : MonoBehaviour
    {
        [SerializeField] Transform pivot;

        private float distanceFromPivot;

        private void Start()
        {
            distanceFromPivot = pivot.position.y - transform.position.y;
        }

        private void Update()
        {
            transform.position = new Vector3(pivot.position.x, pivot.position.y - distanceFromPivot, transform.position.z);
        }
    }
}