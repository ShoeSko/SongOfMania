using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoItem : ObjectBase
{
    private void Awake()
    {
        //Confirm I am Item
        isItem = true;
    }

    public override void OnActivate()
    {
        base.OnActivate();

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
                if (row == 1)
                {
                    inventoryInstance.PickUpItem(name);
                    Destroy(gameObject);
                }
                else
                {
                    dialogueInstance.dialogueStart(22);
                }
                break;

            case 5:
                dialogueInstance.dialogueStart(23);
                break;

            case 6:

                break;

            case 7:

                break;
        }
    }

    public override void OnInspect()
    {
        base.OnInspect();


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
                if (row == 0)
                {
                    SpokenDisplay.ShowDisplaySpoken_Static(itemInstance.myItemList.item[0].inspectPromt);
                }
                else
                {
                    dialogueInstance.dialogueStart(22);
                }
                break;

            case 5:
                dialogueInstance.dialogueStart(23);
                break;

            case 6:

                break;

            case 7:

                break;
        }
    }


}
