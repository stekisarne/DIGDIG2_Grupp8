using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Purchasable : MonoBehaviour
{
    [SerializeField] GameObject textObject;
    [SerializeField] TextMeshPro tmp;
    InventorySystem invSys = null;
    public GameObject[] dropTable;
    [SerializeField] string cantAffordText;
    [SerializeField] string affordText;
    [SerializeField] int price = 10;
    bool canAfford = false;
    bool withinReach = false;
    ItemScript itemScript = null;

    void Start()
    {
        textObject.SetActive(false);
        invSys = GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySystem>();
    }

    void Update()
    {
        if(withinReach && canAfford && Input.GetKeyDown(KeyCode.E))
        {
            buy();
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

    public void buy()
    {
        int i;
        i = Random.Range(0, dropTable.Length);
        print("chest bought" + i);
        SpawnItem(i);
        Destroy(gameObject);
    }

    public void SpawnItem(int i)
    {
        float x = Random.Range(-5, 5);
        Rigidbody2D rbody;
        GameObject item = Instantiate(dropTable[i], transform.position, Quaternion.identity);
        itemScript = item.GetComponent<ItemScript>();
        rbody = item.transform.GetComponent<Rigidbody2D>();
        itemScript.itemIndex = i;
        rbody.AddForce(new Vector2(x, 5), ForceMode2D.Impulse);
    }
}
