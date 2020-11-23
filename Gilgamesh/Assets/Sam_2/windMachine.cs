using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windMachine : MonoBehaviour
{
    public List<GameObject> windList;

    public int spawnInterval = 100;
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (counter % spawnInterval == 0)
        {
            int index = Random.Range(0, 3);
            GameObject newWind = Instantiate(windList[index]);
        }
        counter++;
    }
}
