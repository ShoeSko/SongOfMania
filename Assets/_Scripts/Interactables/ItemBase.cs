using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : ObjectBase
{

    private void Awake()
    {
        //Confirm I am NPC
        isItem = true;

    }

}