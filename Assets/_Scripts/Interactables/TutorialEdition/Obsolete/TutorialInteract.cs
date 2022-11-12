using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInteract : ObjectBase
{
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
        if(row == 3)
        {
            inventoryInstance.PickUpItem(name);
            Destroy(gameObject.transform.parent.gameObject);
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

        if(row == 3)
        {
            SpokenDisplay.ShowDisplaySpoken_Static(itemInstance.myItemList.item[3].inspectPromt);
        }
    }


}
