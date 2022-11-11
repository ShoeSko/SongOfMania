using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FuckItElectricBoogaloo :ObjectBase
{
    [Header("Bookshelf Stool spawn")]
    //I exist only to be summoned in front of a bookshelf
    [SerializeField] private GameObject stoolPrefab;
    [SerializeField] private Transform stoolPlacement;

    [Header("Teleport Variables")]
    [SerializeField] private bool isTeleporter;
    [SerializeField] private bool changeScene;
    [SerializeField] private GameObject[] teleportTarget;
    [SerializeField] private Camera[] cam;

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

            case 5: //Recieve chair

                dialogueInstance.getDialogue(23);
                break;

            case 6: //Key on Door

                break;

            case 7: //Use Door
                if (row == 0)
                {
                    TeleportPlayer(); //If Door + is Teleporter, Send player to location.
                }
                break;
        }
        if (row == 0)
        {
            TeleportPlayer(); //If Door + is Teleporter, Send player to location.
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

                break;

            case 7:

                break;
        }
    }

    public override void OnRecieve()
    {
        base.OnRecieve();
        if (row == 1)
        {
            Instantiate(stoolPlacement, stoolPlacement);
        }
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

                ChangeCamera();
                teleportTarget[0].SetActive(false);
                teleportTarget[1].SetActive(true);
            }
        }
    }

    private void ChangeCamera()
    {
        cam[1].enabled = true;
        cam[0].enabled = false;
    }
}
