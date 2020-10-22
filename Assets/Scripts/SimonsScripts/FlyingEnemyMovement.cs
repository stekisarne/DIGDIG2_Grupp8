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
    public float smoothTime;
    public bool chasing;

    Vector2 patrolPos;
    private Vector2 smoothVelocity = Vector2.zero;
    
    void Start()
    {
        patrolPos = transform.position;
        chasing = false;
    }

    
    void Update()
    {
        FlyingEnemyMove();
    }

    void FlyingEnemyPatrol()
    {
        
        transform.position = new Vector2(patrolPos.x + Mathf.PingPong(Time.time, patrolLength), patrolPos.y);
    }

    void FlyingEnemyMove()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if(distance < detectionRange)
        {
            chasing = true;
            transform.position = Vector2.SmoothDamp(transform.position, player.position, ref smoothVelocity, smoothTime);

            patrolPos = transform.position;
        }
        else
        {
            FlyingEnemyPatrol();
        }
        
    }
}
