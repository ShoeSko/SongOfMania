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
        public string inspectPromt;
        public string FailedPromt;
        public int comboItem;
        public int combineResult;
        public string PickupPrompt;
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
        string[] data = itemDataSheet.text.Split(new string[] { "\t", "\n" }, StringSplitOptions.None);

        //Variable for later, The amount of colloms in the CSV is the first numer and the secondnumber dissreguards the firts row
        int tableSize = data.Length / 6 - 1;
        myItemList.item = new Item[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            myItemList.item[i] = new Item();
            myItemList.item[i].name = data[6 * (i + 1)];
            myItemList.item[i].inspectPromt = data[6 * (i + 1)+1];
            myItemList.item[i].FailedPromt = data[6 * (i + 1)+2];
            myItemList.item[i].comboItem= int.Parse(data[6 * (i + 1)+3]);
            myItemList.item[i].combineResult= int.Parse(data[6 * (i + 1)+4]);
            myItemList.item[i].PickupPrompt= data[6 * (i + 1)+5];
            

        }
    }
}
