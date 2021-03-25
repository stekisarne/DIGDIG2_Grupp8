using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeinHandlerScript : MonoBehaviour
{
    public GameObject Vein;
    public GameObject parent;
    public float VeinCount;
    public float VeinsKilled;

    public Vector3 VeinPos1;
    public Vector3 VeinPos2;
    public Vector3 VeinPos3;
    public Vector3 VeinPos4;

    EnemyHealth VeinHealth;
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
        Instantiate(Vein, VeinPos1, Quaternion.identity, parent.transform);
        Instantiate(Vein, VeinPos2, Quaternion.identity, parent.transform);
        Instantiate(Vein, VeinPos3, Quaternion.identity, parent.transform);
        Instantiate(Vein, VeinPos4, Quaternion.identity, parent.transform);
        VeinHealth = GetComponentInChildren<EnemyHealth>();
    }

    public void VeinKillCounter()
    {
        if(VeinHealth.enemyHp <= 0)
        {
            VeinsKilled += 1;
        }
    }
}
