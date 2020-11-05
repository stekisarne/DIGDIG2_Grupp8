using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatingMovement : MonoBehaviour
{
    Vector3 oscPos;
    [SerializeField] float oscSpeed;
    [SerializeField] float oscLength;
    [SerializeField] float timeOffset;
    Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
        oscPos.y = gameObject.transform.position.y;
    }

    void Update()
    {
        oscPos.y = Mathf.Sin(Time.time + timeOffset * oscSpeed) * oscLength;
        transform.position = startPos + oscPos;
    }
}
