using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    [SerializeField] List<Transform> wantedPositions; //Makes a list with all the waypoints.

    [SerializeField] int currentPosition; //Variable for the slimes currentPosition.

    public bool deatachSlime = true;

    public Transform slimeObject;

    private void Awake()
    {
        if (deatachSlime == true)
        {
            slimeObject.parent = null;
        }
    }

    void Start()
    {
        currentPosition = 0; //Sets the current position of the slime to the first way point in the list.
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, wantedPositions[currentPosition].position) < 0.01f) //Checks where the slime is and if it is close to the waypoint it's going to.
        {
            currentPosition++; //Makes the slime target the next way point.

            if (currentPosition > wantedPositions.Count - 1) //If the slimes is at the last way point it resets which waypoint it'sgoing to.
            {
                currentPosition = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, wantedPositions[currentPosition].position, 2 * Time.deltaTime); //Slime moves towards the next target waypoint in the list.
        transform.rotation = wantedPositions[currentPosition].rotation; //The slime takes the rotation of the current waypoint.
    }
}
