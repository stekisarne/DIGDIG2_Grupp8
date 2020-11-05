using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyMovement : MonoBehaviour
{
    public Rigidbody2D flyingRBody;
    public Transform player;

    public float flyingEnemySpeed;
    public float patrolLength;
    public float detectionRange;
    public float patrolDistance;
    public float smoothTime;

    

    public bool chasing;
    public bool maxDistanceReached;
    public bool chasingDone;

    Vector2 patrolPos;
    private Vector2 smoothVelocity = Vector2.zero;

    void Start()
    {
        patrolPos = transform.position;
        chasing = false;
        maxDistanceReached = false;
        flyingRBody = GetComponent<Rigidbody2D>();
        StartCoroutine("ChangePatrolPos");
    }


    void Update()
    {

    }

    private void FixedUpdate()
    {
        FlyingEnemyMove();
    }

    void FlyingEnemyPatrol()
    {
        float distanceFromPPos = Vector2.Distance(transform.position, patrolPos);

        if (chasing == false && maxDistanceReached == false)
        {
            flyingRBody.velocity = new Vector2(1f * flyingEnemySpeed, 0f);

            if (distanceFromPPos > patrolDistance)
            {

                maxDistanceReached = true;
                

            }
        }
        else if(chasing == false && maxDistanceReached == true)
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

        if (distance < detectionRange)
        {
            chasing = true;

            flyingRBody.MovePosition(flyingRBody.transform.position + dir * flyingEnemySpeed * Time.fixedDeltaTime);

            
            
            
            
        }
        else
        {

            chasing = false;
            FlyingEnemyPatrol();
        }

    }
    IEnumerator ChangePatrolPos()
    {
        patrolPos = flyingRBody.transform.position;
        yield return null;
    }
}
