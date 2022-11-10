using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class csvreader : MonoBehaviour
{
    public TextAsset textAssetData;
    public int listRow;
    public TMP_Text text;


    [System.Serializable]
    public class Item
    {
        public string name;
        public string PickupPrompt;
        public string FailedPromt;
        public string SucsessPromt;
    }
    [System.Serializable]
    public class ItemList
    {
        public Item[] item;
    }
    public ItemList myItemList = new ItemList();
    // Start is called before the first frame update
    void Start()
    {

        ReadCSV();
    }

    public void settRow(int rowNumber)
    {
        listRow = rowNumber;
    }
    public void useFailed()
    {
        print(myItemList.item[listRow].FailedPromt);
        text.text = myItemList.item[listRow].FailedPromt; 
    }
    public void useSucsess()
    {
        print(myItemList.item[listRow].SucsessPromt);
        text.text = myItemList.item[listRow].SucsessPromt;
    }
    public void pickUp()
    {
        print(myItemList.item[listRow].PickupPrompt);
        text.text = myItemList.item[listRow].PickupPrompt;
    }
    public void sayname()
    {

        print(myItemList.item[listRow].name);
        text.text = myItemList.item[listRow].name;
    }

    void ReadCSV()
    {
        //turns the CSV file into a single array, 
        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        //Variable for later, The amount of colloms in the CSV is the first numer and the secondnumber dissreguards the firts row
        int tableSize = data.Length / 4 - 1;
        myItemList.item = new Item[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            myItemList.item[i] = new Item();
            myItemList.item[i].name = data[4 * (i + 1)];
            myItemList.item[i].PickupPrompt = data[4 * (i + 1) + 1];
            myItemList.item[i].FailedPromt = data[4 * (i + 1) + 2];
            myItemList.item[i].SucsessPromt = data[4 * (i + 1) + 3];
        }
    }

}
