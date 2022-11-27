using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeanChest : ObjectBase
{
    [Header("Highlight needs")]
    [SerializeField] private MeshRenderer[] materialsToChange;
    [SerializeField] private Material originalChestMaterial;

    public static int chestOpened;

    private void Awake()
    {
        //Confirm I am Item
        isInteractable = true;

        chestOpened = 0;
    }


    public override void OnActivate()
    {
        base.OnActivate();
        SpokenDisplay.ShowDisplaySpoken_Static(interactableInstace.myInteractableList.interactable[0].inspectPromt);
    }

    public override void OnInspect()
    {
        base.OnInspect();
        SpokenDisplay.ShowDisplaySpoken_Static(interactableInstace.myInteractableList.interactable[0].inspectPromt);
    }

    public override void OnRecieve()
    {
        string itemName = inventoryInstance.selectedItem;
        base.OnRecieve();

        if(itemName == "chest key")
        {
            if(chestOpened != 2)
            {
                SpokenDisplay.ShowDisplaySpoken_Static("Nothing to find in this one...");
                chestOpened++;
                Destroy(this);
            }
            else if(chestOpened >= 2)
            {
                inventoryInstance.UseItem("Chest", false);
                inventoryInstance.PickUpItem("multi use trophy");

                if (!SeanPuzzleComplete.s_seanPuzzleDone)
                {
                    SeanPuzzleComplete.s_seanPuzzleDone = true;
                    dialogueInstance.dialogueStart(30);
                }

                Destroy(this);
            }
        }
    }

    public override void HighlightInteractable()
    {
        //Trigger Highlight
        if (Input.GetMouseButton(2) && !isNPC && !Dialogue.isDialogue || Input.GetKey(KeyCode.Space) && !isNPC && !Dialogue.isDialogue)
        {
            //Get reference to Highlight material that is in asset folder called Resource0s
            Material highlightMaterial = Resources.Load("Highlight_Material", typeof(Material)) as Material;
            for (int i = 0; i < materialsToChange.Length; i++)
            {
                //Get Refernece to Object Meshrender & set material to highlightMaterial
                materialsToChange[i].material = highlightMaterial;
            }
        }
        else if (!isNPC)
        {
            for (int i = 0; i < materialsToChange.Length; i++)
            {
                //Get Reference to Object Meshrender & set material to originalMaterial (Stored in start)
                materialsToChange[i].material = originalChestMaterial;
            }
        }
    }
}
