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
                    dialogueInstance.dialogueStart(4);
                    break;

                case 1:
                    dialogueInstance.dialogueStart(7);
                    break;

                case 2:
                    dialogueInstance.dialogueStart(10);
                    break;

                case 3: //Find Key
                    if (row == 1)
                    {
                        dialogueInstance.dialogueStart(16);
                        ++TutorialManager.s_tutorialStage;
                    }
                    else
                    {
                        dialogueInstance.dialogueStart(15);
                    }
                    break;

                case 4: //Pick Up Chair
                    dialogueInstance.dialogueStart(22);
                    break;

                case 5: //Place Chair on Bookshelf
                    dialogueInstance.dialogueStart(23);
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
                    dialogueInstance.dialogueStart(4);
                    break;

                case 1:
                    dialogueInstance.dialogueStart(7);
                    break;

                case 2:
                    dialogueInstance.dialogueStart(10);
                    break;

                case 3: //Find Key
                    if (row == 1)
                    {
                        dialogueInstance.dialogueStart(16);
                        ++TutorialManager.s_tutorialStage;
                    }
                    else
                    {
                        dialogueInstance.dialogueStart(15);
                    }
                    break;

                case 4: //Pick Up Chair
                    dialogueInstance.dialogueStart(22);
                    break;

                case 5:
                    dialogueInstance.dialogueStart(23);
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
            audioSourceInstance.PlayOneShot(audioClip);
            Instantiate(stoolPrefab, stoolPlacement);
            inventoryInstance.UseItem("bookshelf", true);
            ++TutorialManager.s_tutorialStage;
            //Destroy the key
            Destroy(gameObject);
        }
    }

    public override void HighlightInteractable()
    {
        //if (!JuiceToggle.s_juiceHighlight)
        //{
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
        //}
    }
}
