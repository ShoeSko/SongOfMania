using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class itemCSVreader : MonoBehaviour
{
    public TextAsset itemDataSheet;

    [System.Serializable]
    public class Item
    {
        public string name;
        public string PickupPrompt;
        public string FailedPromt;
        public string sucsessPromt;
        public string inspectPromt;
        public bool singleUse;
        public int comboItem;
    }
    [System.Serializable]
    public class ItemList
    {
        public Item[] item;
    }
    public ItemList myItemList = new ItemList();

    void Start()
    {
        readItemCSV();
    }

    void readItemCSV()
    {
        string[] data = itemDataSheet.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        //Variable for later, The amount of colloms in the CSV is the first numer and the secondnumber dissreguards the firts row
        int tableSize = data.Length / 7 - 1;
        myItemList.item = new Item[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            myItemList.item[i] = new Item();
            myItemList.item[i].name = data[7 * (i + 1)];
            myItemList.item[i].PickupPrompt = data[7 * (i + 1) + 1];
            myItemList.item[i].FailedPromt = data[7 * (i + 1) + 2];
            myItemList.item[i].sucsessPromt = data[7 * (i + 1) + 3];
            myItemList.item[i].inspectPromt = data[7 * (i + 1) + 4];
            myItemList.item[i].singleUse = bool.Parse(data[7 * (i + 1) + 5]);
            myItemList.item[i].comboItem = int.Parse(data[7 * (i + 1) + 6]);

        }
    }
}
