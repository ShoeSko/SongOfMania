using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuckItTesting : ObjectBase
{
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
        switch (TutorialManager.s_tutorialStage)
        {
            case 0:
                dialogueInstance.getDialogue(4);
                break;
                
            case 1:
                dialogueInstance.getDialogue(7);
                break;

            case 2:
                if (row == 0)
                {
                    dialogueInstance.getDialogue(11);
                    ++TutorialManager.s_tutorialStage;
                }
                else
                {
                    dialogueInstance.getDialogue(10);
                }
                break;

            case 3:
                dialogueInstance.getDialogue(15);
                break;

            case 4:
                dialogueInstance.getDialogue(22);
                break;

            case 5:
                dialogueInstance.getDialogue(23);
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
            case 0: //You should move
                dialogueInstance.getDialogue(4);
                break;

            case 1: //Inspect Door
                if(row == 0)
                {
                    dialogueInstance.getDialogue(8);
                    ++TutorialManager.s_tutorialStage;
                }
                else
                {
                    dialogueInstance.getDialogue(7);
                }
                break;

            case 2: //Use Door
                dialogueInstance.getDialogue(10);
                break;

            case 3: //Find Key
                dialogueInstance.getDialogue(15);
                break;

            case 4: //Pick Up Chair
                dialogueInstance.getDialogue(22);
                break;

            case 5: //Chair on Bookshelf
                dialogueInstance.getDialogue(23);
                break;

            case 6:

                break;

            case 7:

                break;
        }
    }
}
