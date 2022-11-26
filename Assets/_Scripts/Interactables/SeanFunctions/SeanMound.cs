using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeanMound : ObjectBase
{
    private void Awake()
    {
        //Confirm I am Item
        isInteractable = true;
    }


    public override void OnActivate()
    {
        base.OnActivate();
    }

    public override void OnInspect()
    {
        base.OnInspect();

    }
}
