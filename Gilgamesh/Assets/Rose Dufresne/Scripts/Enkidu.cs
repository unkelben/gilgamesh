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
        public float weightBalance { get; set; }
        private bool increaseWeight;
        public float interval { get; set; }
        private Vector3 initialScale;
        private Vector3 targetScale;
        private bool targetFormAchieved;
        private bool targetSizeAchieved;
        private float weightGained;

        public Stack<float> clayWeights { get; set; }

        private float OscillationTimer;

        // Start is called before the first frame update
        void Start()
        {
            clayWeights = new Stack<float>();

            targetScale = enkidu.transform.localScale;
            enkidu.transform.localScale = new Vector3(0, 0, 0);
            initialScale = enkidu.transform.localScale;
            weightToAdd = 0;
            //weight = 100;
            weightBalance = -30f;
            interval = 0;
            increaseWeight = false;
            targetFormAchieved = false;
            targetSizeAchieved = false;
            blendshapes = enkidu.GetComponent<SkinnedMeshRenderer>();
            
            blendshapes.SetBlendShapeWeight(3, weightBalance * (-100f / 30f)); //body
        }

        // Update is called once per frame
        void Update()
        {
            weightGained = (100 - weightBalance * (-100f / 30f));

            if ((int)weightGained > (int)interval) //remove weight
            {
                weightBalance -= weightToAdd / 10f * Time.deltaTime;
                if (weightGained <= 130 && weightGained >= 30 && !targetFormAchieved)
                {
                    blendshapes.SetBlendShapeWeight(3, weightBalance * (-100f / 30f)+30f);
                }

                UpdateScale();
            }
            else if ((int)weightGained < (int)interval) //add weight
            {
                weightBalance += weightToAdd / 10f * Time.deltaTime;
                if (weightGained <= 130 && weightGained >= 30 && !targetFormAchieved)
                {
                    blendshapes.SetBlendShapeWeight(3, (weightBalance * (-100f / 30f))+30f);
                }
                UpdateScale();
            }
            else
            {
                weightBalance = ((int)interval - 100) / (100f) * 30f;
            }


            if (blendshapes.GetBlendShapeWeight(3) <= 0)
            {
                targetFormAchieved = true;
            }

            if (enkidu.transform.localScale == targetScale)
            {
                targetSizeAchieved = true;
            }
        }

        private void UpdateScale()
        {
            enkidu.transform.localScale = new Vector3(initialScale.x + weightGained, initialScale.y + weightGained, initialScale.z + weightGained)*0.5f;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Clay")
            {
                if (!other.GetComponent<Clay>().isInHand)
                {
                    increaseWeight = true;
                    weightToAdd = other.GetComponent<Clay>().weight;
                    interval += weightToAdd;
                    clayWeights.Push(other.GetComponent<Clay>().weight);
                    Destroy(other.gameObject);
                }
            }
        }

        private void IncreaseWeight()
        {
            weightBalance += weightToAdd / 10f * Time.deltaTime;
            if (weightBalance * (-100f / 30f) >= 0)
                blendshapes.SetBlendShapeWeight(3, weightBalance * (-100f / 30f));

            UpdateScale();
            if (weightBalance * (-100f / 30f) <= 100 - interval)
            {
                increaseWeight = false;
            }
        }

        public void DecreaseWeight()
        {
            weightBalance -= weightToAdd / 10f * Time.deltaTime;
            if (weightBalance * (-100f / 30f) <= 100)
                blendshapes.SetBlendShapeWeight(3, weightBalance * (-100f / 30f));

            UpdateScale();
        }
    }
}


//float headWeight = 0;
//float arm_R_Weight = 100;
//float arm_L_Weight = 100;

//set up blend shapes
//blendshapes.SetBlendShapeWeight(0, 0f); //arm_L
//blendshapes.SetBlendShapeWeight(1, 0f); //arm_R
//blendshapes.SetBlendShapeWeight(2, 0f); //head

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
