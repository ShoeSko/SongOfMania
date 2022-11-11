using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Items> itemList;
    public Inventory()
    {
        itemList = new List<Items>();

        Debug.Log("inventory ");
        AddItem(new Items { itemType = Items.ItemType.Stool, amount = 1 });
        Debug.Log(itemList.Count);
    }

    public void AddItem(Items item)
    {
        itemList.Add(item);
    }
}
