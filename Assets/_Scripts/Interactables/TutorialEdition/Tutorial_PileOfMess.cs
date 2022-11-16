using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_PileOfMess : ObjectBase
{
    [SerializeField] private MeshRenderer[] materialsToChange;
    [SerializeField] private Material originalPileGarbageMaterial;

    private void Awake()
    {
        //Confirm I am Interactable
        isInteractable = true;
    }

    public override void OnActivate()
    {
        print("Triggered");
        print(TutorialManager.s_tutorialStage);
        base.OnActivate();

        if (row == 3)
        {
            //Trigger Inspection  //Change to else?
            SpokenDisplay.ShowDisplaySpoken_Static(interactableInstace.myInteractableList.interactable[3].inspectPromt);
        }
    }

    public override void OnInspect()
    {
        base.OnInspect();

        if (row == 3)
        {
            //Pile Inspect
            SpokenDisplay.ShowDisplaySpoken_Static(interactableInstace.myInteractableList.interactable[3].inspectPromt);
        }
    }

    public override void OnRecieve()
    {
        string itemName = inventoryInstance.selectedItem;
        base.OnRecieve();
        print(itemName + " was given to " + name);

        if (row == 3 && itemName == "rake")
        {
            inventoryInstance.UseItem("pile_of_mess", true);
            Destroy(gameObject);
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
                materialsToChange[i].material = originalPileGarbageMaterial;
            }
        }
    }
}
