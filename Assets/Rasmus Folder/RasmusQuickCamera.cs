using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RasmusQuickCamera : MonoBehaviour
{

    public Transform followTransform;
    public int sceneIndex;
    [SerializeField] float camYOffset;


    // Update is called once per frame
    void FixedUpdate()
    {
        if(sceneIndex == 0)
        {
            this.transform.position = new Vector3(this.transform.position.x, followTransform.position.y + camYOffset, this.transform.position.z);
        }
        else
        {
            this.transform.position = new Vector3(this.transform.position.x, followTransform.position.y, this.transform.position.z);
        }
    }
}