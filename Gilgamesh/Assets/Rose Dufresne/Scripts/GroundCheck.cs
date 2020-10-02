using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour
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
}