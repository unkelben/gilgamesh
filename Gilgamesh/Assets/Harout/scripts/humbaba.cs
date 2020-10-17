using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humbaba : enemy
{
    public Transform target;

    public float chaseRad;
    public float attackRad;
    public Transform homePos;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector2.Distance(target.position, transform.position) <= chaseRad)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }
}

