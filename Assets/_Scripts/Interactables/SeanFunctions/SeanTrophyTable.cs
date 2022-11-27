using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeanTrophyTable : ObjectBase
{
    [SerializeField] private List<GameObject> listOfTrophies = new List<GameObject>();
    private int trophiesPlaced;
    public static bool s_doneWithPuzzles;

    private void Awake()
    {
        //Confirm I am Item
        isInteractable = true;

        s_doneWithPuzzles = false;
    }


    public override void OnActivate()
    {
        base.OnActivate();
        SpokenDisplay.ShowDisplaySpoken_Static("I should put something valuable on here.");
    }

    public override void OnInspect()
    {
        base.OnInspect();
        SpokenDisplay.ShowDisplaySpoken_Static("Seems a bit empty doesn't it?");
    }

    public override void OnRecieve()
    {
        string itemName = inventoryInstance.selectedItem;
        base.OnRecieve();

        if (itemName == "multi use trophy")
        {
            listOfTrophies[2].SetActive(true);
            inventoryInstance.UseItem("table", false);
            trophiesPlaced++;
            print("Trophy placed");
        }
        else if (itemName == "Single use Trhophy")
        {
            listOfTrophies[1].SetActive(true);
            inventoryInstance.UseItem("table", false);
            trophiesPlaced++;
            print("Trophy placed");
        }
        else if (itemName == "NPC interaction Trophy ")
        {
            listOfTrophies[0].SetActive(true);
            inventoryInstance.UseItem("table", false);
            trophiesPlaced++;
            print("Trophy placed");
        }

        if(trophiesPlaced >= 3)
        {
            dialogueInstance.dialogueStart(34);
            s_doneWithPuzzles = true;
        }
    }

    public override void DisplayName()
    {
    NameDisplay.ShowDisplayName_Static("Trophy Table");

    }
}
