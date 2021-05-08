using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyMovement : MonoBehaviour
{
    public Rigidbody2D flyingRBody;
    public GameObject player;
    public float distanceFromPlayer;
    public float flyingEnemySpeed;
    public float chasingSpeed;
    public float detectionRange;
    public float patrolDistance;
    
    

    public bool maxDistanceReached;

    Vector3 patrolPos;

   public AudioSource chargeNoise;

    public enum State { Patrolling, Chasing, Idle, Exploding }
    public State currentState;

    void Start()
    {
        patrolPos = transform.position;
        
        maxDistanceReached = false;

        flyingRBody = GetComponent<Rigidbody2D>();

        currentState = State.Patrolling;

        player = GameObject.FindGameObjectWithTag("Player");
        distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);
    }



    private void Update()
    {
        FlyingEnemyPatrol();
        FlyingEnemyMove();
        
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

         distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);

        
        Vector3 dir = (player.transform.position - flyingRBody.transform.position).normalized;

        if (currentState == State.Idle && distanceFromPlayer < detectionRange || currentState == State.Patrolling && distanceFromPlayer < detectionRange)
        {

            flyingRBody.velocity = Vector2.zero;
            chargeNoise.Play();
            currentState = State.Chasing;
            
        }

        if (currentState == State.Chasing)
        {
            flyingRBody.MovePosition(flyingRBody.transform.position + dir * chasingSpeed * Time.deltaTime);
            
        }
        else if (currentState == State.Patrolling)
        {
            return;
        }
        

    }

    
}
