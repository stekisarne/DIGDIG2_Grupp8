using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    private float lengthY, startposY, lengthX, startposX;
    public GameObject player;
    public float parallaxEffectY;
    public float parallaxEffectX;
    void Start()
    {
        startposY = transform.position.y;
        lengthY = GetComponent<SpriteRenderer>().bounds.size.y;
        startposX = transform.position.x;
        lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float tempY = (player.transform.position.y * (1 - parallaxEffectY));
        float distY = (player.transform.position.y * parallaxEffectY);
        float tempX = (player.transform.position.x * (1 - parallaxEffectX));
        float distX = (player.transform.position.x * parallaxEffectX);

        transform.position = new Vector3(startposX + distX, startposY + distY, transform.position.z);

        if (tempY > startposY + lengthY) startposY += lengthY;
        else if (tempY < startposY - lengthY) startposY -= lengthY;
        if (tempX > startposX + lengthX) startposX += lengthX;
        else if (tempX < startposX - lengthX) startposX -= lengthX;
    }
}
