using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Balance
{
    public class BalanceTilting : MonoBehaviour
    {
        [SerializeField] GameObject enkidu;
        public float weight = -30;

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
            weight = enkidu.GetComponent<Enkidu>().weightBalance;
            rotationAngleZ = weight;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, rotationAngleZ);
            
        }
    }
}
