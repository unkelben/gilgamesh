using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCamera : MonoBehaviour
{
    Vector3 camPos;
    // Start is called before the first frame update
    void Start()
    {
        camPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        Debug.Log(camPos);
    }

    private void Reset()
    {
        gameObject.transform.position = camPos;
        Debug.Log(camPos);
    }
}
