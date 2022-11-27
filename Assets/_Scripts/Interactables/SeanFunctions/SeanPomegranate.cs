using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeanPomegranate : ObjectBase
{
    [Header("Highlight needs")]
    [SerializeField] private MeshRenderer[] materialsToChange;
    [SerializeField] private Material originalPomegranateMaterial;

    private void Awake()
    {
        //Confirm I am Item
        isItem = true;
    }


    public override void OnActivate()
    {
        base.OnActivate();
        if (row == 3)
        {
            inventoryInstance.PickUpItem(name);
            Destroy(gameObject);
        }
    }

    public override void OnInspect()
    {
        base.OnInspect();
        SpokenDisplay.ShowDisplaySpoken_Static(itemInstance.myItemList.item[3].inspectPromt);
    }

    public override void HighlightInteractable()
    {
        if (!JuiceToggle.s_juiceHighlight)
        {
            //Trigger Highlight
            if (Input.GetMouseButton(2) && !isNPC && !Dialogue.isDialogue || Input.GetKey(KeyCode.Space) && !isNPC && !Dialogue.isDialogue)
            {
                //Get reference to Highlight material that is in asset folder called Resource0s
                Material highlightMaterial = Resources.Load("Highlight_Material", typeof(Material)) as Material;
                for (int i = 0; i < materialsToChange.Length; i++)
                {
                    //Get Refernece to Object Meshrender & set material to highlightMaterial
                    materialsToChange[i].material = highlightMaterial;
                }
            }
            else if (!isNPC)
            {
                for (int i = 0; i < materialsToChange.Length; i++)
                {
                    //Get Reference to Object Meshrender & set material to originalMaterial (Stored in start)
                    materialsToChange[i].material = originalPomegranateMaterial;
                }
            }
        }
    }
}
