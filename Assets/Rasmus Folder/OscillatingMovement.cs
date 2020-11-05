using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatingMovement : MonoBehaviour
{
    Vector3 oscPos;
    [SerializeField] float oscSpeed;
    [SerializeField] float oscLength;
    [SerializeField] float timeOffset;
    void Start()
    {
        oscPos = gameObject.transform.position;
    }

    void Update()
    {

        if (Time.time > timeOffset)
        {
            oscPos.y = Mathf.Sin(Time.time * oscSpeed) * oscLength;
            transform.position = oscPos;

        }

    }
}
