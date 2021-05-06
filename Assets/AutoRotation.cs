using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotation : MonoBehaviour
{
    public float rotationSpeed;
    public enum Directions { right, left };
    public enum Mode { rotation, oscillation };

    public Directions dir;
    public Mode mode;
    public float oscillationDegree;
    public float oscFreq;
    float rot;


    void Update()
    {
        if (mode == Mode.rotation)
        {
            if (dir == Directions.left)
            {
                transform.Rotate(0, 0, -1 * rotationSpeed * Time.deltaTime);
            }
            else if (dir == Directions.right)
            {
                transform.Rotate(0, 0, 1 * rotationSpeed * Time.deltaTime);
            }
        }
        if (mode == Mode.oscillation)
        {
            rot = Mathf.Sin(Time.time * Mathf.PI * oscFreq);
            transform.rotation = Quaternion.Euler(0, 0, rot * oscillationDegree);
            print(rot);
        }
    }
}
