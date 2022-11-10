using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class dialogueCSV : MonoBehaviour
{
    public TextAsset textAssetData;

    [System.Serializable]
    public class Dialogue
    {
        public string name;
        public string promt;
        public string who;
        public string Position;
        public string partner;
        public int next;

    }
    [System.Serializable]
    public class dialogueList
    {
        public Dialogue[] dialogue;
    }
    public dialogueList myDialogueList = new dialogueList();
    // Start is called before the first frame update
    void Start()
    {
        readTSV();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            readTSV();
        }
    }


    void readTSV()
    {
        //turns the CSV file into a single array, 
        string[] data = textAssetData.text.Split(new string[] { "\t", "\n" }, StringSplitOptions.None);

        //Variable for later, The amount of colloms in the CSV is the first numer and the secondnumber dissreguards the firts row
        int tableSize = data.Length / 6 - 1;
        myDialogueList.dialogue = new Dialogue[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            myDialogueList.dialogue[i] = new Dialogue();
            myDialogueList.dialogue[i].name = data[6 * (i + 1)];
            myDialogueList.dialogue[i].promt = data[6 * (i + 1) + 1];
            myDialogueList.dialogue[i].who = data[6 * (i + 1) + 2];
            myDialogueList.dialogue[i].Position = data[6 * (i + 1) + 3];
            myDialogueList.dialogue[i].partner = data[6 * (i + 1) + 4];
            myDialogueList.dialogue[i].next = int.Parse(data[6 * (i + 1) + 5]);
        }
    }
}
