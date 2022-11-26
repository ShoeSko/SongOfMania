using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeanShovelHead : ObjectBase
{
    private void Awake()
    {
        //Confirm I am Item
        isItem = true;
    }


    public override void OnActivate()
    {
        base.OnActivate();
        if (row == 0)
        {
            inventoryInstance.PickUpItem(name);
            Destroy(gameObject);
        }
    }

    public override void OnInspect()
    {
        base.OnInspect();
        SpokenDisplay.ShowDisplaySpoken_Static(itemInstance.myItemList.item[0].inspectPromt);
    }
}
