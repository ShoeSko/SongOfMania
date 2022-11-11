using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Inventory_Items : MonoBehaviour
{
    public TextAsset itemDataSheet;

    public Dictionary<string, Item> items;

    public List<string> inventory;

    public string selectedItem;

    public List<GameObject> barItems;
    public GameObject itemBG;

    public List<Sprite> itemIcons;

    public itemCSVreader itemInstance { get; protected set; }

    private void Start()
    {
        selectedItem = null;
        inventory = new List<string>();
        readItemTSV();

        itemInstance = FindObjectOfType<itemCSVreader>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(items["lyre"].name);

            //foreach (KeyValuePair<string, Item> k in items)
            //{
            //    Debug.Log($"{k.Key} - {k.Value.name}\n{k.Value.onInspect}\n{k.Value.onFailedUse}\n{k.Value.onPickup}\n{k.Value.combineWith} - {k.Value.combineResult}\n-----");
            //}
        }
    }

    public void SelectItem(int itemPos)
    {
        if (itemPos < inventory.Count)
        {
            if (inventory[itemPos] == selectedItem)
            {
                selectedItem = null;
                itemBG.SetActive(false);
            }
            else
            {
                selectedItem = inventory[itemPos];
                itemBG.transform.position = barItems[itemPos].transform.position;
                itemBG.SetActive(true);
            }

            Debug.Log($"Selected item: {selectedItem}");
        }

    }

    private void UpdateInventory()
    {
        itemBG.SetActive(false);
        if (!inventory.Contains(selectedItem)) selectedItem = null;


        for (int i = 0; i < barItems.Count; i++)
        {
            if (inventory.Count > i)
            {
                switch (inventory[i])
                {
                    case "stool":
                        barItems[i].GetComponent<Image>().sprite = itemIcons[0];
                        break;
                    case "key":
                        barItems[i].GetComponent<Image>().sprite = itemIcons[1];
                        break;
                    case "broken_lyre":
                        barItems[i].GetComponent<Image>().sprite = itemIcons[2];
                        break;
                    case "rake":
                        barItems[i].GetComponent<Image>().sprite = itemIcons[3];
                        break;
                    case "lyre_string":
                        barItems[i].GetComponent<Image>().sprite = itemIcons[4];
                        break;
                    case "lyre":
                        barItems[i].GetComponent<Image>().sprite = itemIcons[5];
                        break;
                    default:
                        break;
                }

            }
            else
            {
                barItems[i].GetComponent<Image>().sprite = null;
            }
        }
        // Refresh inventory visuals


    }

    public void OnInspect(string itemName)
    {
        // Send dialogue
        SpokenDisplay.ShowDisplaySpoken_Static(items[itemName].onInspect);
        // [TextScript].write(items[itemName].onInspect)

        // Temp
        Debug.Log(items[itemName].onInspect);
    }

    public void OnInspect(int itemPos)
    {
        if (itemPos < inventory.Count)
        {
            // Send dialogue
            SpokenDisplay.ShowDisplaySpoken_Static(items[inventory[itemPos]].onInspect);
            // [TextScript].write(items[inventory[itemPos]].onInspect)

            // Temp
            Debug.Log(items[inventory[itemPos]].onInspect);
        }
    }

    public void PickUpItem(string itemName)
    {
        inventory.Add(itemName);
        UpdateInventory();

        // Send dialogue
        SpokenDisplay.ShowDisplaySpoken_Static(items[itemName].onPickup);
        // [TextScript].write(items[itemName].onPickup)

        // Temp
        Debug.Log(items[itemName].onPickup);
    }

    public bool UseItem(string targetItem, bool pickup)
    {
        if (selectedItem != null && items[selectedItem].combineWith == targetItem)
        {
            inventory.Remove(selectedItem);

            if (pickup)
                PickUpItem(items[selectedItem].combineResult.Trim());

            UpdateInventory();
            selectedItem = null;

            return true;
        }

        // Send dialogue
        SpokenDisplay.ShowDisplaySpoken_Static(items[targetItem].onPickup);
        // [TextScript].write(items[itemName].onPickup)

        // Temp
        Debug.Log(items[selectedItem].onFailedUse);
        return false;
    }

    public void UseItem(int itemPos)
    {
        if (itemPos < inventory.Count)
        {
            if (inventory[itemPos] == selectedItem)
            {
                selectedItem = null;
                itemBG.SetActive(false);
                return;
            }

            if (items[selectedItem].combineWith == inventory[itemPos])
            {
                inventory.Remove(inventory[itemPos]);
                inventory.Remove(selectedItem);

                PickUpItem(items[selectedItem].combineResult.Trim());
                UpdateInventory();
            }

            if (selectedItem == null) return;

            // Send dialogue
            SpokenDisplay.ShowDisplaySpoken_Static(items[inventory[itemPos]].onPickup);
            // [TextScript].write(items[itemName].onPickup)

            // Temp
            Debug.Log(items[selectedItem].onFailedUse);
        }
    }

    void readItemTSV()
    {
        string[] data = itemDataSheet.text.Split(new string[] { "\t", "\n" }, StringSplitOptions.None);

        items = new Dictionary<string, Item>();

        for (int i = 0; i < data.Length; i += 7)
        {
            Item item = new Item(data[i + 1], data[i + 2], data[i + 3], data[i + 4], data[i + 5], data[i + 6]);
            items[data[i]] = item;
        }
    }
}

public class Item
{
    public string name;
    public string onInspect;
    public string onFailedUse;
    public string onPickup;
    public string combineWith;
    public string combineResult;

    public Item(string name, string onInspect, string onFailedUse, string onPickup, string combineWith, string combineResult)
    {
        this.name = name;
        this.onInspect = onInspect;
        this.onFailedUse = onFailedUse;
        this.onPickup = onPickup;
        this.combineWith = combineWith;
        this.combineResult = combineResult;
    }
}