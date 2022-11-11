
public class TutorialInteractable : InteractableBase
{
    public override void OnActivate()
    {
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
                dialogueInstance.getDialogue(10);
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
            case 0:
                dialogueInstance.getDialogue(4);
                break;

            case 1:
                dialogueInstance.getDialogue(7);
                break;

            case 2:
                dialogueInstance.getDialogue(10);
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
    private void LateUpdate()
    {
        print(TutorialManager.s_tutorialStage);
        print("HELP ME");
    }

    private void OnMouseExit()
    {
        print("Hi");
    }
}
