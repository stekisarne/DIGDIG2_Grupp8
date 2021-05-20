using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossZoomTriggerScript : MonoBehaviour
{
    public RasmusQuickCamera camS;
    public EaterScript eS;

    public GameObject paralaxBackgorunds;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ZoomTrigger")
        {
            eS.bossTime = true;
            camS.newZoom = 11.83f;
            Destroy(paralaxBackgorunds, 1f);
        }
    }
}
