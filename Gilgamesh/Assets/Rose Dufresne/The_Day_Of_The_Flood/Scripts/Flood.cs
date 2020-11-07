using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rose.World
{
    public class Flood : MonoBehaviour
    {
        [SerializeField] private float speed;
        private SkinnedMeshRenderer skinMesh;
        private CircleCollider2D circleCollider;
        private float initialRadius;
        private float skinMeshWeight;

        private void Start()
        {
            skinMesh = GetComponent<SkinnedMeshRenderer>();
            circleCollider = GetComponent<CircleCollider2D>();
            initialRadius = circleCollider.radius;
            skinMeshWeight = 0;
        }

        private void Update()
        {
            skinMeshWeight += speed * Time.deltaTime;
            skinMesh.SetBlendShapeWeight(0, skinMeshWeight);
            circleCollider.radius = initialRadius * (1 - (skinMesh.GetBlendShapeWeight(0)/100f));
        }
    }
}
