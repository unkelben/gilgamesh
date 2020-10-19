using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rose.Clay
{
    using Rose.Balance;

    public class RemoveClay : MonoBehaviour
    {
        [SerializeField] GameObject enkiduStand;
        [SerializeField] GameObject clayPrefab;

        private bool clayCanBeRemoved;
        private bool decreaseWeight;
        private Transform claySpawnPosition;
        private float interval;
        private float weightBalance;

        // Start is called before the first frame update
        void Start()
        {
            interval = 0;
            clayCanBeRemoved = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp("space"))
            {
                clayCanBeRemoved = false;
            }

            if (Input.GetKeyDown("space") && clayCanBeRemoved)
            {
                decreaseWeight = true;
                GameObject clay = Instantiate(clayPrefab, claySpawnPosition.position + new Vector3(0,0.7f,0), Quaternion.identity) as GameObject;
                clay.GetComponent<Clay>().weight = enkiduStand.GetComponent<Enkidu>().clayWeights.Pop();
                clay.transform.parent = claySpawnPosition.parent;
                clay.tag = "Clay";
                interval = clay.GetComponent<Clay>().weight;
                enkiduStand.GetComponent<Enkidu>().interval -= interval;
                clayCanBeRemoved = false;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "PinchLimit" && enkiduStand.GetComponent<Enkidu>().clayWeights.Count > 0)
            {
                clayCanBeRemoved = true;
                claySpawnPosition = other.gameObject.transform;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "PinchLimit")
            {
                clayCanBeRemoved = false;
            }
        }
    }

}