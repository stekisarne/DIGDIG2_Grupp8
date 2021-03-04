using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeinHandlerScript : MonoBehaviour
{
    public GameObject Vein;
    public GameObject parent;
    public float VeinCount;
    public Vector3 VeinPos1;
    public Vector3 VeinPos2;
    public Vector3 VeinPos3;
    public Vector3 VeinPos4;
    // Start is called before the first frame update
    void Start()
    {
        VeinPos1 = new Vector3(parent.transform.position.x - 4f, parent.transform.position.y, 0);
        VeinPos2 = new Vector3(parent.transform.position.x, parent.transform.position.y + 4f, 0);
        VeinPos3 = new Vector3(parent.transform.position.x + 4f, parent.transform.position.y, 0);
        VeinPos4 = new Vector3(parent.transform.position.x, parent.transform.position.y - 4f, 0);
        SpawnVeins();
    }

    // Update is called once per frame
    void Update()
    {
        VeinCount = transform.childCount;
    }

   public void SpawnVeins()
    {
        Instantiate(Vein, new Vector3(0, 0, 0), Quaternion.identity, parent.transform);
        Instantiate(Vein, new Vector3(0, 0, 0), Quaternion.identity, parent.transform);
        Instantiate(Vein, new Vector3(0, 0, 0), Quaternion.identity, parent.transform);
        Instantiate(Vein, new Vector3(0, 0, 0), Quaternion.identity, parent.transform);
    }
}
