using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Stool : ObjectBase
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
                    dialogueInstance.dialogueStart(4);
                    break;

                case 1:
                    dialogueInstance.dialogueStart(7);
                    break;

                case 2:
                    dialogueInstance.dialogueStart(10);
                    break;

                case 3: //Find Key
                    dialogueInstance.dialogueStart(15);
                    break;

                case 4: //Pick Up Chair
                    if (row == 0)
                    {
                        audioSourceInstance.PlayOneShot(audioClip);
                        inventoryInstance.PickUpItem(name);
                        ++TutorialManager.s_tutorialStage;
                        Destroy(gameObject);
                    }
                    else
                    {
                        dialogueInstance.dialogueStart(22);
                    }
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
                    dialogueInstance.dialogueStart(15);
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
            }
        }
    }
}
