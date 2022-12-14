using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class dialogueTSVreader : MonoBehaviour
{
    public TextAsset textAssetData;

    [System.Serializable]
    public class Dialogue
    {
        //all variables in the data sheet.
        public string name;
        public string promt;
        public string who;
        public string Position;
        public string partner;
        public int next;
        public int audioEmotion;
    }

    [System.Serializable]
    public class DialogueList
    {
        public Dialogue[] dialogue;
    }

    public DialogueList myDialogueList = new DialogueList();

    private void Start()
    {
        readTSV();
    }
    void readTSV()
    {
        //turns the TSV file into a single array, 
        string[] data = textAssetData.text.Split(new string[] { "\t", "\n" }, StringSplitOptions.None);

        //Variable for later, The amount of colloms in the CSV is the first numer and the secondnumber dissreguards the firts row
        int tableSize = data.Length / 7 - 1;
        myDialogueList.dialogue = new Dialogue[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            myDialogueList.dialogue[i] = new Dialogue();
            myDialogueList.dialogue[i].name = data[7 * (i + 1)];
            myDialogueList.dialogue[i].promt = data[7 * (i + 1) + 1];
            myDialogueList.dialogue[i].who = data[7 * (i + 1) + 2];
            myDialogueList.dialogue[i].Position = data[7 * (i + 1) + 3];
            myDialogueList.dialogue[i].partner = data[7 * (i + 1) + 4];
            myDialogueList.dialogue[i].next = int.Parse(data[7 * (i + 1) + 5]);
            myDialogueList.dialogue[i].audioEmotion = int.Parse(data[7 * (i + 1) + 6]);
        }
    }
}
