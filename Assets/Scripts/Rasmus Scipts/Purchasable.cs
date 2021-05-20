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
    bool canAfford = false;
    bool withinReach = false;
    ItemScript itemScript = null;
    public Animator chestAnim;
    public AudioSource sSource;
    public AudioClip sClip;
    bool bought = false;

    void Start()
    {
        textObject.SetActive(false);
        invSys = GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySystem>();
    }

    void Update()
    {
        if (withinReach && Input.GetButtonDown("Fire1"))
        {
            if (!bought)
            {
                buy();
            }

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
        if(!bought) textObject.SetActive(true);
    }

    public void buy()
    {
        int i;
        i = Random.Range(0, dropTable.Length);
        print("chest bought" + i);
        SpawnItem(i);
        chestAnim.SetBool("poped", true);
        sSource.PlayOneShot(sClip);
        bought = true;
    }

    public void SpawnItem(int i)
    {
        float x = Random.Range(-5, 5); //random force on x axis
        Rigidbody2D rbody;
        GameObject item = Instantiate(dropTable[i], transform.position, Quaternion.identity);
        itemScript = item.GetComponent<ItemScript>();
        rbody = item.transform.GetComponent<Rigidbody2D>();
        itemScript.itemIndex = i;
        rbody.AddForce(new Vector2(x, 5), ForceMode2D.Impulse);
    }
}
