using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyMovement : MonoBehaviour
{
    public Rigidbody2D flyingRBody;
    public Transform player;

    public float flyingEnemySpeed;
    public float chasingSpeed;
    public float detectionRange;
    public float patrolDistance;
    public float returnTime;
    public float maxSpeed;

    public bool maxDistanceReached;

    Vector3 patrolPos;
    

    private enum State { Patrolling, Chasing, Idle }
    State currentState;

    void Start()
    {
        patrolPos = transform.position;
        
        maxDistanceReached = false;

        flyingRBody = GetComponent<Rigidbody2D>();

        currentState = State.Patrolling;
        
    }



    private void Update()
    {
        FlyingEnemyPatrol();
        FlyingEnemyMove();
        ReturnToPatrol();
    }

    

    void FlyingEnemyPatrol()
    {
        float distanceFromPPos = Vector2.Distance(transform.position, patrolPos);
        
        if (currentState == State.Patrolling && maxDistanceReached == false)
        {
            flyingRBody.velocity = new Vector2(1f * flyingEnemySpeed, 0f);

            if (distanceFromPPos > patrolDistance)
            {
                maxDistanceReached = true;
            }
        }
        else if(currentState == State.Patrolling && maxDistanceReached == true)
        {
            flyingRBody.velocity = new Vector2(-1f * flyingEnemySpeed, 0f);

            if(distanceFromPPos == 0)
            {
                maxDistanceReached = false;
            }
        }
    }

    void FlyingEnemyMove()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        Vector3 dir = (player.transform.position - flyingRBody.transform.position).normalized;

        if (currentState == State.Idle && distance < detectionRange || currentState == State.Patrolling && distance < detectionRange)
        {
            flyingRBody.velocity = Vector2.zero;
            currentState = State.Chasing;
            Debug.Log("pat");
        }

        if (currentState == State.Chasing && distance < detectionRange)
        {
            flyingRBody.MovePosition(flyingRBody.transform.position + dir * chasingSpeed * Time.deltaTime);
        }
        else if (currentState == State.Patrolling)
        {
            return;
        }
        else if(currentState == State.Chasing && distance > detectionRange)
        {
            currentState = State.Idle;
        }

    }

    private void ReturnToPatrol()
    {
        

       
    }
}
