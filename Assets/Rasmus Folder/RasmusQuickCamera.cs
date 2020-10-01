using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RasmusQuickCamera : MonoBehaviour
{

    public Transform followTransform;


    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(this.transform.position.x, followTransform.position.y, this.transform.position.z);


    }
}