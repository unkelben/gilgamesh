using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Balance
{
    public class BalanceTilting : MonoBehaviour
    {
        public float weight;

        private float rotationAngleZ;

        // Start is called before the first frame update
        void Start()
        {
            rotationAngleZ = 0;
        }

        // Update is called once per frame
        void Update()
        {
            RotateBalanceBar();
        }

        void RotateBalanceBar()
        {
            rotationAngleZ = weight;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, rotationAngleZ);
        }
    }
}
