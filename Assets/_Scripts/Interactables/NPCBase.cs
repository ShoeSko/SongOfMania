using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Billboard))]
public class NPCBase : ObjectBase
{

    [SerializeField] private int dialogueIndexToCall;
    private void Awake()
    {
        //Confirm I am NPC
        isNPC = true;
    }

    public override void OnActivate()
    {
        base.OnActivate();
        dialogueInstance.getDialogue(dialogueIndexToCall);
    }

    public override void OnInspect()
    {
        base.OnInspect();
        SpokenDisplay.ShowDisplaySpoken_Static("This MOTHERF****R");
    }
}
