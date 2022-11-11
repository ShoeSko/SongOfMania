using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBase : ObjectBase
{

    private void Awake()
    {
        //Confirm I am NPC
        isInteractable = true;
    }
}
