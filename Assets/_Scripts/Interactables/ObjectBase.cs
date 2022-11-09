using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//It is a must that an interactable has a collider
[RequireComponent(typeof(Collider))]
public class ObjectBase : MonoBehaviour
{
    [Header("Item Parameters")]
    [Tooltip("Is this object an Item?")] 
    public bool isItem;
    public string itemName;
    private int itemSheet;
    private int itemRow;

    [Header("Interactable Parameter")]
    [Tooltip("Is this object an interactable?")]
    public bool isInteractable;
    public string interactableName;
    private int interactableSheet;
    private int interactableRow;

    private Material originalMaterial;


    private void Start()
    {
        //Initiate call to CVS info?
        //Fill current with needed information.

        if(isItem || isInteractable)
        {
            originalMaterial = gameObject.GetComponent<MeshRenderer>().material;
        }
    }

    private void Update()
    {
        HighlightInteractable();
    }

    /// <summary>
    /// When you Right Click this object it will ...
    /// </summary>
    public virtual void OnRightClick()
    {
        //Right Click Function

        //Input.mousebutton(0) down.
        //IF(Close enough)
        //Else move Player

        //Prevent movement due to click?
    }

    /// <summary>
    /// When you Left Click this object it will prompt an observation dialog.
    /// </summary>
    public virtual void OnLeftClick()
    {
        //Left Click Function

        //Input.mousebutton(1) down. Then....
    }


    /// <summary>
    /// Highlight this object when pressing scroll wheel / Space button
    /// </summary>
    private void HighlightInteractable()
    {
        //Trigger Highlight
        if (Input.GetMouseButton(2) || Input.GetKey(KeyCode.Space))
        {
            Material highlightMaterial = Resources.Load("Highlight_Material", typeof(Material)) as Material;

            MeshRenderer interactMesh = gameObject.GetComponent<MeshRenderer>();
            interactMesh.material = highlightMaterial;
        }
        else
        {
            MeshRenderer interactMesh = gameObject.GetComponent<MeshRenderer>();
            interactMesh.material = originalMaterial;
        }
    }

    /// <summary>
    /// Displays the name of the current object when hovered over.
    /// </summary>
    private void DisplayName()
    {
        //Trigger from OnMouseOver
        //Have reference to text object
        //Display Name from Sheet/Given in text
        //Hide when no longer
        if (isItem)
        {

            NameDisplay.ShowDisplayName_Static(itemName);
        }
        else if (isInteractable)
        {
            NameDisplay.ShowDisplayName_Static(interactableName);
        }
        else
        {
            //Inser NPC Name Condition here
        }
    }



    /// <summary>
    /// Triggers Right/Left Click Highlight & Display Name
    /// For ease of not having to Raycast.
    /// </summary>
    private void OnMouseOver()
    {

        //Trigger Display Name
            DisplayName();
    }

    /// <summary>
    /// Trigger removal of Name Display
    /// </summary>
    private void OnMouseExit()
    {
        //Hide the Name displayed when no longer hovering.
        NameDisplay.HideDisplayName_Static();
    }
}
