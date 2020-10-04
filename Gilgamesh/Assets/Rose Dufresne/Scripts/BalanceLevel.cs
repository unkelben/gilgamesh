using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceLevel : MonoBehaviour
{
    [SerializeField] Transform platform;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, platform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, platform.position.y, transform.position.z);
    }
}
