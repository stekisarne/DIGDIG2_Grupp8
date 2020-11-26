using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    public int startingMoney = 0;
    public int currentMoney;
    public List<Items> items = new List<Items>(); //creates a new list based on the class Items
    public float arrowmulti; //example delete me
    public GameObject itemsMenu;
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

    public void AddItem(int itemIndex) //adds one to specific itemCounter
    {
        print("itemindex" + itemIndex);
        items[itemIndex].itemCount++;
        items[itemIndex].UpdateItems();
    }

    public void UpdateInventory()
    {
        foreach (Items item in items)
        {
            switch (item.itemName) // string in case should line up with name in inspector
            {
                case "Arrow"://example delete later
                    arrowmulti = item.itemCount;
                    print("arrow" + arrowmulti);
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
    public Sprite itemSprite;
    public TextMeshProUGUI tmpro; // text to change depending ón itemCount

    public void UpdateItems()
    {
        tmpro.text = itemCount.ToString();
    }
}