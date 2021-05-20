using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public int itemIndex;
    InventorySystem invSys = null;
    bool pickedUp = false;
    float timer = 0.05f;

    void Start()
    {
        invSys = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventorySystem>();
    }

    void Update()
    {
        timer = timer - 1f * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && pickedUp == false && timer <= 0f)
        {
            PickUp();
            pickedUp = true;
        }
    }

    public void PickUp()
    {
        invSys.AddItem();
        Destroy(gameObject);
    }
}
