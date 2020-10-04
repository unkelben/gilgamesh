using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enkidu : MonoBehaviour
{

    [SerializeField] GameObject enkidu;

    private SkinnedMeshRenderer blendshapes;
    private float weight;
    public float weightBalance { get; set; }
    private bool increaseWeight;
    private float interval;

    float headWeight = 0;
    float arm_R_Weight = 100;
    float arm_L_Weight = 100;

    // Start is called before the first frame update
    void Start()
    {
        weight = 100;
        weightBalance = -30f;
        interval = 10;
        increaseWeight = false;
        blendshapes = enkidu.GetComponent<SkinnedMeshRenderer>();
        blendshapes.SetBlendShapeWeight(0, 0f); //arm_L
        blendshapes.SetBlendShapeWeight(1, 0f); //arm_R
        blendshapes.SetBlendShapeWeight(2, 0f); //head
        blendshapes.SetBlendShapeWeight(3, 100f); //body
    }

    // Update is called once per frame
    void Update()
    {
        if (increaseWeight)
        {
            weight -= 10*Time.deltaTime;
            weightBalance += 3* Time.deltaTime;
            blendshapes.SetBlendShapeWeight(3, weight);
            if (weight <= 100-interval)
            {
                interval += 10;
                increaseWeight = false;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Clay")
        {
            if (blendshapes.GetBlendShapeWeight(3) > 0)
            {
                increaseWeight = true;
            }
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

            Destroy(other.collider.gameObject);
        }
    }
}
