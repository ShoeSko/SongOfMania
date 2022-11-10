using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Billboard))]
public class NPCBase : ObjectBase
{
    private void Awake()
    {
        //Confirm I am NPC
        isNPC = true;
    }


}
