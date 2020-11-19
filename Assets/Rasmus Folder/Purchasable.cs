using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Purchasable : MonoBehaviour
{
    [SerializeField] GameObject textObject;
    [SerializeField] TextMeshPro tmp;
    InventorySystem invSys = null;
    [SerializeField] string cantAffordText;
    [SerializeField] string affordText;
    [SerializeField] int price = 10;
    bool canAfford = false;
    bool withinReach = false;

    void Start()
    {
        textObject.SetActive(false);
        invSys = GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySystem>();
    }

    void Update()
    {
        if(withinReach && canAfford && Input.GetKeyDown(KeyCode.E))
        {

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            withinReach = true;
            DisplayText();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            withinReach = false;
            textObject.SetActive(false);
        }
    }

    void DisplayText()
    {
        textObject.SetActive(true);

        if (invSys.currentMoney < price)
        {
            canAfford = false;
            tmp.text = cantAffordText;
        }

        else if(invSys.currentMoney >= price)
        {
            canAfford = true;
            tmp.text = affordText;
        }
    }
}
