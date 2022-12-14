using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutoInteract : ObjectBase
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
                dialogueInstance.dialogueStart(4);
                break;

            case 1:
                dialogueInstance.dialogueStart(7);
                break;

            case 2:
                if (row == 0)
                {
                    print("now playing 11");
                    dialogueInstance.dialogueStart(11);
                    ++TutorialManager.s_tutorialStage;
                }
                else
                {
                    dialogueInstance.dialogueStart(10);
                }
                break;

            case 3:
                dialogueInstance.dialogueStart(15);
                break;

            case 4:
                dialogueInstance.dialogueStart(22);
                break;

            case 5: //Recieve chair

                dialogueInstance.dialogueStart(23);
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
    }

    public override void OnInspect()
    {
        base.OnInspect();

        switch (TutorialManager.s_tutorialStage)
        {
            case 0: //You should move
                dialogueInstance.dialogueStart(4);
                break;

            case 1: //Inspect Door
                if (row == 0)
                {
                    dialogueInstance.dialogueStart(8);
                    ++TutorialManager.s_tutorialStage;
                }
                else
                {
                    dialogueInstance.dialogueStart(7);
                }
                break;

            case 2: //Use Door
                dialogueInstance.dialogueStart(10);
                break;

            case 3: //Find Key
                dialogueInstance.dialogueStart(15);
                break;

            case 4: //Pick Up Chair
                dialogueInstance.dialogueStart(22);
                break;

            case 5: //Chair on Bookshelf
                dialogueInstance.dialogueStart(23);
                break;

            case 6:

                break;

            case 7:

                break;
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
