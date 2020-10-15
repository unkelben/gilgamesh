using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rose.Balance
{
    using Rose.Clay;

    public class Enkidu : MonoBehaviour
    {
        [SerializeField] GameObject enkidu;

        private SkinnedMeshRenderer blendshapes;
        //private float weight;
        private float weightToAdd;
        public float weightBalance;
        private bool increaseWeight;
        public float interval;
        private Vector3 initialScale;

        public Stack<float> clayWeights;

        //float headWeight = 0;
        //float arm_R_Weight = 100;
        //float arm_L_Weight = 100;

        // Start is called before the first frame update
        void Start()
        {
            clayWeights = new Stack<float>();

            initialScale = enkidu.transform.localScale;
            weightToAdd = 0;
            //weight = 100;
            weightBalance = -30f;
            interval = 0;
            increaseWeight = false;
            blendshapes = enkidu.GetComponent<SkinnedMeshRenderer>();

            //set up blend shapes
            blendshapes.SetBlendShapeWeight(0, 0f); //arm_L
            blendshapes.SetBlendShapeWeight(1, 0f); //arm_R
            blendshapes.SetBlendShapeWeight(2, 0f); //head
            blendshapes.SetBlendShapeWeight(3, weightBalance * (-100f / 30f)); //body
        }

        // Update is called once per frame
        void Update()
        {
            //if (increaseWeight)
            //{
            //    IncreaseWeight();
            //}

            if (100 - weightBalance * (-100f / 30f) >= interval) //remove weight
            {
                weightBalance -= weightToAdd / 10f * Time.deltaTime;
                if (weightBalance * (-100f / 30f) <= 100)
                    blendshapes.SetBlendShapeWeight(3, weightBalance * (-100f / 30f));

                DecreaseScale();
            }
            else //add weight
            {
                weightBalance += weightToAdd / 10f * Time.deltaTime;
                if (weightBalance * (-100f / 30f) >= 0)
                    blendshapes.SetBlendShapeWeight(3, weightBalance * (-100f / 30f));

                IncreaseScale();
            }
        }

        private void IncreaseWeight()
        {
            weightBalance += weightToAdd / 10f * Time.deltaTime;
            if (weightBalance * (-100f / 30f) >= 0)
                blendshapes.SetBlendShapeWeight(3, weightBalance * (-100f / 30f));

            IncreaseScale();
            if (weightBalance * (-100f / 30f) <= 100 - interval)
            {
                increaseWeight = false;
            }
        }

        public float DecreaseWeight(float weightToAdd)
        {
            weightBalance -= weightToAdd / 10f * Time.deltaTime;
            if (weightBalance * (-100f / 30f) <= 100)
                blendshapes.SetBlendShapeWeight(3, weightBalance * (-100f / 30f));

            DecreaseScale();
            return weightBalance * (-100f / 30f);
        }

        private void IncreaseScale()
        {
            if (weightBalance * (-100f / 30f) <= 0 && weightBalance * (-100f / 30f) >= -30f)
            {
                enkidu.transform.localScale = new Vector3(initialScale.x - weightBalance * (-100f / 30f), initialScale.y - weightBalance * (-100f / 30f), initialScale.z - weightBalance * (-100f / 30f));
            }
        }

        private void DecreaseScale()
        {
            if (weightBalance * (-100f / 30f) <= 0 && weightBalance * (-100f / 30f) >= -30f)
            {
                enkidu.transform.localScale = new Vector3(initialScale.x + weightBalance * (-100f / 30f), initialScale.y + weightBalance * (-100f / 30f), initialScale.z + weightBalance * (-100f / 30f));
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.tag == "Clay"/* && other.collider.transform.parent == null*/)
            {
                if (!other.collider.GetComponent<Clay>().isInHand)
                {
                    increaseWeight = true;
                    weightToAdd = other.collider.GetComponent<Clay>().clayWeight;
                    //weightToAdd = 20; //shhh... hardcoded
                    interval += weightToAdd;

                    //if (blendshapes.GetBlendShapeWeight(3) <= 50 && blendshapes.GetBlendShapeWeight(2) <= 100)
                    //{
                    //    blendshapes.SetBlendShapeWeight(2, headWeight+50);
                    //}
                    //if (blendshapes.GetBlendShapeWeight(1) > 0 && blendshapes.GetBlendShapeWeight(2) >= 100)
                    //{
                    //    blendshapes.SetBlendShapeWeight(1, arm_R_Weight-50);
                    //}
                    //if (blendshapes.GetBlendShapeWeight(0) > 0 && blendshapes.GetBlendShapeWeight(1) <= 0)
                    //{
                    //    blendshapes.SetBlendShapeWeight(0, arm_L_Weight-50);
                    //}

                    clayWeights.Push(other.collider.GetComponent<Clay>().clayWeight);
                    Destroy(other.collider.gameObject);
                }
            }
        }
    }
}
