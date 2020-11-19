using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public int startingMoney = 0;
    public int currentMoney;
    public List<Items> items = new List<Items>();
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void AddItem(int itemIndex)
    {
        print("itemindex" + itemIndex);
        items[itemIndex].itemCount++;
    }
}
[System.Serializable]
public class Items
{
    public string itemName;
    public int itemCount;
    public Sprite itemSprite;
}