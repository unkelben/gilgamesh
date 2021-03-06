﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humbaba : enemy
{
    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRad;
    public float attackRad;
    public Transform homePos;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector2.Distance(target.position, transform.position) <= chaseRad)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector2 temp = transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
            }
        }
    }


    private void ChangeState (EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }


}

