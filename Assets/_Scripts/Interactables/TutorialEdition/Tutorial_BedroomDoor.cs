using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial_BedroomDoor : ObjectBase
{
    [Header("Teleport Variables")]
    [SerializeField] private bool isTeleporter;
    [SerializeField] private bool changeScene;
    [SerializeField] private GameObject[] teleportTarget;

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

                case 5: //Recieve chair

                    dialogueInstance.getDialogue(23);
                    break;

                case 6: //Key on Door
                    SpokenDisplay.ShowDisplaySpoken_Static(itemInstance.myItemList.item[1].inspectPromt);
                    break;

                case 7: //Use Door
                    if (row == 0)
                    {
                        TeleportPlayer(); //If Door + is Teleporter, Send player to location.
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
                case 0: //You should move
                    dialogueInstance.getDialogue(4);
                    break;

                case 1: //Inspect Door
                    if (row == 0)
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
                    SpokenDisplay.ShowDisplaySpoken_Static(itemInstance.myItemList.item[1].inspectPromt);
                    break;
            }
        }
    }

    public override void OnRecieve()
    {
        string itemName = inventoryInstance.selectedItem;
        base.OnRecieve();
        print(itemName + " was given to " + name);

        if (row == 0)
        {
            inventoryInstance.UseItem("door_bedroom", false);
            StartCoroutine(UnlockingDoor());
            TeleportPlayer(); //If Door + is Teleporter, Send player to location.
        }
    }

    IEnumerator UnlockingDoor()
    {
        yield return new WaitForSeconds(.5f);
        ++TutorialManager.s_tutorialStage;
    }
    private void TeleportPlayer()
    {
        if (isTeleporter)
        {
            if (changeScene)
            {
                //Scene command here
                SceneManager.LoadScene(2); //Supposed credit Page?
            }
            else
            {
                teleportTarget[1].SetActive(true);
                teleportTarget[0].SetActive(false);
                ChangeCamera();
                TutorialManager.s_leftBedroom = true;
                StartCoroutine(WaitToHaveAChat());
                this.GetComponent<TutorialItem>().enabled = false;
            }
        }
    }

    private void ChangeCamera()
    {
        CameraBasicFollow.changeCamLoc = true;
    }

    IEnumerator WaitToHaveAChat()
    {
        yield return new WaitForSeconds(0.5f);
        dialogueInstance.getDialogue(27);
        inventoryInstance.PickUpItem("broken_lyre");
    }
}
