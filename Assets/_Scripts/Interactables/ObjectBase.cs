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

    [Header("NPC Parameter")]
    public bool isNPC;


    [Header("Hidden Variables")]
    private Material originalMaterial;


    private void Start()
    {
        //Initiate call to CVS info?
        //Fill current with needed information.

        if(!isNPC)
        {
            //Store current material for end of highligh
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
    public virtual void OnActivate()
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
    public virtual void OnInspect()
    {
        //Left Click Function

        //Input.mousebutton(1) down. Then....
    }

    /// <summary>
    /// When you 
    /// 1 Have item in inventory selected and click
    /// 2 Drag item in inventory over and release
    /// Do This.
    /// </summary>
    public virtual void OnRecieve()
    {

    }


    /// <summary>
    /// Highlight this object when pressing scroll wheel / Space button
    /// Unless NPC
    /// </summary>
    private void HighlightInteractable()
    {
        //Trigger Highlight
        if (Input.GetMouseButton(2) || Input.GetKey(KeyCode.Space) && !isNPC)
        {
            //Get reference to Highlight material that is in asset folder called Resources
            Material highlightMaterial = Resources.Load("Highlight_Material", typeof(Material)) as Material;

            //Get Refernece to Object Meshrender & set material to highlightMaterial
            MeshRenderer interactMesh = gameObject.GetComponent<MeshRenderer>();
            interactMesh.material = highlightMaterial;
        }
        else if (!isNPC)
        {
            //Get Reference to Object Meshrender & set material to originalMaterial (Stored in start)
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
        //Trigger OnActivate
        OnActivate();
        //Trigger OnInspect
        OnInspect();
        //Trigger OnRecieve
        OnRecieve();
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
