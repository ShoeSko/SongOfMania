using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeanChest : ObjectBase
{
    [Header("Highlight needs")]
    [SerializeField] private MeshRenderer[] materialsToChange;
    [SerializeField] private Material originalChestMaterial;

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

    public override void OnRecieve()
    {
        base.OnRecieve();
    }

    public override void HighlightInteractable()
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
                materialsToChange[i].material = originalChestMaterial;
            }
        }
    }
}
