using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RasmusQuickCamera : MonoBehaviour
{

    public Transform followTransform; // transform to follow
    public int sceneIndex; // Current SceneIndex
    [SerializeField] float camYOffset; // Offset on y axis. Used only in main menu


    // Update is called once per frame
    void FixedUpdate()
    {
        if(sceneIndex == 0) // Scene = MainMenu follows player on y axis but adds offset
        {
            this.transform.position = new Vector3(this.transform.position.x, followTransform.position.y + camYOffset, this.transform.position.z);
        }
        else // Scene != Main Menu follows player on y axis with no offset
        {
            this.transform.position = new Vector3(this.transform.position.x, followTransform.position.y, this.transform.position.z);
        }
    }
}