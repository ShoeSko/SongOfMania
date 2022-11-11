using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_inventory : MonoBehaviour
{

    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlotContainer = transform.Find("ItemSlots");
    }
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    private void RefreshInventoryItems()
    {

    }
}
