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
        while(Time.time > timeOffset)
        {
            oscPos.y = Mathf.PingPong(Time.time * oscSpeed, oscLength) - oscLength / 2;
            transform.position = oscPos;
        }
    }
}
