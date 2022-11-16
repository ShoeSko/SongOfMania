using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Key : ObjectBase
{
    [Header("Key Collection Settings")]
    //I exist only to be summoned in front of a bookshelf
    [SerializeField] private GameObject stoolPrefab;
    [SerializeField] private Transform stoolPlacement;

    [Header("Highlight needs")]
    [SerializeField] private MeshRenderer[] materialsToChange;
    [SerializeField] private Material originalRakeMaterial;

    private void Awake()
    {
        //Confirm I am Item
        isItem = true;
    }

    public override void OnActivate()
    {
        base.OnActivate();

        if (!TutorialManager.s_leftBedroom)
        {
            switch (TutorialManager.s_tutorialStage)
            {
                case 0:
                    dialogueInstance.getDialogue(4);
                    break;

                case 1:
                    dialogueInstance.getDialogue(7);
                    break;

                case 2:
                    dialogueInstance.getDialogue(10);
                    break;

                case 3: //Find Key
                    if (row == 1)
                    {
                        dialogueInstance.getDialogue(16);
                        ++TutorialManager.s_tutorialStage;
                    }
                    else
                    {
                        dialogueInstance.getDialogue(15);
                    }
                    break;

                case 4: //Pick Up Chair
                    if (row == 0)
                    {
                        inventoryInstance.PickUpItem(name);
                        ++TutorialManager.s_tutorialStage;
                        Destroy(gameObject);
                    }
                    else
                    {
                        dialogueInstance.getDialogue(22);
                    }
                    break;

                case 5: //Place Chair on Bookshelf
                    dialogueInstance.getDialogue(23);
                    break;

                case 6:
                    SpokenDisplay.ShowDisplaySpoken_Static(itemInstance.myItemList.item[1].inspectPromt);
                    break;

                case 7:

                    break;
            }
        }
    }

    public override void OnInspect()
    {
        base.OnInspect();

        if (!TutorialManager.s_leftBedroom)
        {

            switch (TutorialManager.s_tutorialStage)
            {
                case 0:
                    dialogueInstance.getDialogue(4);
                    break;

                case 1:
                    dialogueInstance.getDialogue(7);
                    break;

                case 2:
                    dialogueInstance.getDialogue(10);
                    break;

                case 3: //Find Key
                    if (row == 1)
                    {
                        dialogueInstance.getDialogue(16);
                        ++TutorialManager.s_tutorialStage;
                    }
                    else
                    {
                        dialogueInstance.getDialogue(15);
                    }
                    break;

                case 4: //Pick Up Chair
                    if (row == 0)
                    {
                        SpokenDisplay.ShowDisplaySpoken_Static(itemInstance.myItemList.item[0].inspectPromt);
                    }
                    else
                    {
                        dialogueInstance.getDialogue(22);
                    }
                    break;

                case 5:
                    dialogueInstance.getDialogue(23);
                    break;

                case 6:
                    SpokenDisplay.ShowDisplaySpoken_Static(itemInstance.myItemList.item[1].inspectPromt);
                    break;

                case 7:

                    break;
            }
        }
    }

    public override void OnRecieve()
    {
        string itemName = inventoryInstance.selectedItem;
        base.OnRecieve();
        print(itemName + " was given to " + name);

        base.OnRecieve();
        if (row == 1 && itemName == "stool")
        {
            Instantiate(stoolPrefab, stoolPlacement);
            inventoryInstance.UseItem("bookshelf", true);
            ++TutorialManager.s_tutorialStage;
            //Destroy the key
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
                materialsToChange[i].material = originalRakeMaterial;
            }
        }
    }
}
