using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeanNPC : ObjectBase
{
    [SerializeField] private int npcIDGiven;
    private void Awake()
    {
        //Confirm I am NPC
        isNPC = true;
    }

    public override void OnActivate()
    {
        base.OnActivate();
        switch (npcIDGiven)
        {
            case 0:
                dialogueInstance.dialogueStart(11);
                break;

            case 1:
                dialogueInstance.dialogueStart(20);
                break;

            case 2:
                dialogueInstance.dialogueStart(27);
                break;

            default:
                Debug.Log("Who the fuck am I?");
                break;
        }
    }

    public override void OnInspect()
    {
        base.OnInspect();
        OnActivate();
    }

    public override void OnRecieve()
    {
        base.OnRecieve();

    }

}
