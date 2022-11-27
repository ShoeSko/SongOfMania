using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeanNPC : ObjectBase
{
    [SerializeField] private int npcIDGiven;
    private void Awake()
    {
        //Confirm I am NPC
        isNPC = true;
    }

    public override void OnActivate()
    {
        base.OnActivate();
        switch (npcIDGiven)
        {
            case 0:
                dialogueInstance.dialogueStart(10);
                break;

            case 1:
                dialogueInstance.dialogueStart(18);
                break;

            case 2:
                dialogueInstance.dialogueStart(26);
                break;

            default:
                Debug.Log("Who the fuck am I?");
                break;
        }
    }

    public override void OnInspect()
    {
        base.OnInspect();
        OnActivate();
    }

    public override void OnRecieve()
    {
        string itemName = inventoryInstance.selectedItem;
        base.OnRecieve();

        if(npcIDGiven == 1 && itemName == "Pomegranet")
        {

            inventoryInstance.UseItem("Explainer", false);
            inventoryInstance.PickUpItem("NPC interaction Trophy ");

            if (!SeanPuzzleComplete.s_seanPuzzleDone)
            {
                SeanPuzzleComplete.s_seanPuzzleDone = true;
                dialogueInstance.dialogueStart(30);
            }
        }
    }

}
