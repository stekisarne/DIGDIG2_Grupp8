using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    public List<Items> items = new List<Items>(); //creates a new list based on the class Items
    public GameObject itemsMenu;
    public StatSheet statSheet;
    public PlayerHpScript playerHp;
    void Start()
    {
        itemsMenu.SetActive(false);
    }

    void Update()
    {
        UpdateInventory();
        if (Input.GetKey(KeyCode.Tab))
        {
            itemsMenu.SetActive(true);
        }
        else
        {
            itemsMenu.SetActive(false);
        }
    }

    public void AddItem() //adds one to specific itemCounter
    {
        //("itemindex" + itemIndex);
        //items[itemIndex].itemCount++;
        //items[itemIndex].UpdateItems();
        playerHp.AddHP();
    }

    public void RemoveItem(int itemIndex)
    {
        items[itemIndex].itemCount--;
        items[itemIndex].UpdateItems();
    }

    public void UpdateInventory()
    {
        foreach (Items item in items)
        {
            switch (item.itemName) // string in case should line up with name in inspector
            {
                case "Health":
                    
                    break;

                case "Power":
                    statSheet.powerMultiplier = 1 + (item.itemCount * 0.1f);
                    break;

                default:
                    break;
            }
        }
    }
}

[System.Serializable]
public class Items // simple class to store item variables
{
    public string itemName;
    public int itemCount;
    public TextMeshProUGUI tmpro; // text to change depending on itemCount

    public void UpdateItems()
    {
        tmpro.text = itemCount.ToString();
    }
}