using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class interactableCSVreader : MonoBehaviour
{
    public TextAsset itemDataSheet;

    [System.Serializable]
    public class Interactable
    {
        public string name;
        public string inspectPromt;
        public string usePromt;
        public int multiClick;
    }
    [System.Serializable]
    public class InteractableList
    {
        public Interactable[] interactable;
    }
    public InteractableList myInteractableList = new InteractableList();

    void Start()
    {
        readItemCSV();
    }

    void readItemCSV()
    {
        string[] data = itemDataSheet.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        //Variable for later, The amount of colloms in the CSV is the first numer and the secondnumber dissreguards the firts row
        int tableSize = data.Length / 4 - 1;
        myInteractableList.interactable = new Interactable[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            myInteractableList.interactable[i] = new Interactable();
            myInteractableList.interactable[i].name = data[4 * (i + 1)];
            myInteractableList.interactable[i].inspectPromt = data[4 * (i + 1)+1];
            myInteractableList.interactable[i].usePromt = data[4 * (i + 1) + 2];
        
        }
    }
}
