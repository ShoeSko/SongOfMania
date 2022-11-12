using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPCBase : ObjectBase
{
    [SerializeField] private int dialogueIndexToCall;
    private void Awake()
    {

        //Confirm I am NPC
        isNPC = true;
    }

    public override void OnActivate()
    {
        base.OnActivate();
        SpokenDisplay.ShowDisplaySpoken_Static(interactableInstace.myInteractableList.interactable[2].inspectPromt);
    }

    public override void OnInspect()
    {
        base.OnInspect();
        SpokenDisplay.ShowDisplaySpoken_Static(interactableInstace.myInteractableList.interactable[2].inspectPromt);
    }

    public override void OnRecieve()
    {
        string itemName = inventoryInstance.selectedItem;
        base.OnRecieve();
        print(itemName + " was given to " + name);


        if (row == 2 && itemName == "lyre")
        {
            inventoryInstance.UseItem("orpheus", false);
            //This one dialogue bit needs fixing later.
            dialogueInstance.getDialogue(45);
            TutorialManager.s_finishedTutorial = true;
        }
    }
}
