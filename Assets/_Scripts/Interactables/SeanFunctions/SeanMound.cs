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
        SpokenDisplay.ShowDisplaySpoken_Static(interactableInstace.myInteractableList.interactable[1].inspectPromt);
    }

    public override void OnInspect()
    {
        base.OnInspect();
        SpokenDisplay.ShowDisplaySpoken_Static(interactableInstace.myInteractableList.interactable[1].inspectPromt);
    }

    public override void OnRecieve()
    {
        string itemName = inventoryInstance.selectedItem;
        base.OnRecieve();

        if(itemName == "Shovel")
        { //Destroy Mound and Give Item
            inventoryInstance.UseItem("shovel", false);
            inventoryInstance.PickUpItem("multi use trophy");
            Destroy(gameObject);
        }
    }
}
