using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class itemsGet : MonoBehaviour
{
    private Inventory inventory;

    [SerializeField] private UI_inventory uiInventory;
    private void Awake()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }
}
