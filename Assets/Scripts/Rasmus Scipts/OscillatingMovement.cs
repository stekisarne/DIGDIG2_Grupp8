using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatingMovement : MonoBehaviour
{
    Vector3 oscPos; // oscillating value. Don't touch
    [SerializeField] float oscSpeed; // frequency of sine wave
    [SerializeField] float oscLength; // Amplitude and movement speed of sine wave
    [SerializeField] float timeOffset; // changes phase or start point of sine wave
    [SerializeField] GameObject parent;
    Vector3 startPos;
    public bool limit;
    public float limitThreshold;
    enum Vectors { x, y } // Direction of oscillating movement
    [SerializeField] Vectors oscVector;
    void Start()
    {
        oscPos.y = 0;
        oscPos.x = 0;
    }

    void Update()
    {
        startPos = parent.transform.position;
        startPos.y = parent.transform.position.y + 0.2f;
        Oscillate();
    }

    void Oscillate()
    {
        switch (oscVector)
        {
            case Vectors.x:
                oscPos.x = Mathf.Sin(Time.time * Mathf.PI * oscSpeed + timeOffset) * oscLength; // gives oscPos.x the value of a sine wave acording to time.time and different variables
                transform.position = startPos + oscPos; // Moves object with oscPos sine wave in x axis
                break;

            case Vectors.y:
                oscPos.y = Mathf.Sin(Time.time * Mathf.PI * oscSpeed + timeOffset) * oscLength; // gives oscPos.y the value of a sine wave acording to time.time and different variables
                if (limit)
                {
                    if (oscPos.y >= limitThreshold)
                    {
                        oscPos.y = limitThreshold;
                    }
                    else if (oscPos.y <= -limitThreshold)
                    {
                        oscPos.y = -limitThreshold;
                    }
                }
                transform.position = startPos + oscPos; // Moves object with oscPos sine wave in y axis
                break;
        }
    }
}
