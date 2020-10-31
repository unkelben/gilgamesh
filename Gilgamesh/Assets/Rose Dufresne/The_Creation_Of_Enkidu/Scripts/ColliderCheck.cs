using UnityEngine;
using System.Collections;

namespace Rose.ClawMachine
{
    public class ColliderCheck : MonoBehaviour
    {
        public bool CheckGrounded(float radius, LayerMask whatIsGround, GameObject ignoreObject = null)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius, whatIsGround);
            foreach (Collider col in colliders)
            {
                if (col.gameObject != ignoreObject)
                {
                    return true;
                }
            }
            return false;
        }

        //public bool ClayCheck(Vector3 halfExtents, LayerMask whatIsClay, GameObject ignoreObject = null)
        //{
        //    Collider[] colliders = Physics.OverlapBox(transform.position, halfExtents, transform.rotation, whatIsClay);
        //    foreach (Collider col in colliders)
        //    {
        //        if (col.gameObject != ignoreObject)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}