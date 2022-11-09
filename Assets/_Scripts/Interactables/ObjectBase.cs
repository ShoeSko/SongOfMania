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
    private int itemSheet;
    private int itemRow;
    public string itemName;

    [Header("Interactable Parameter")]
    [Tooltip("Is this object an interactable?")]
    public bool isInteractable;
    private int interactableSheet;
    private int interactableRow;
    public string interactableName;

    private void Start()
    {
        //Initiate call to CVS info?
        //Fill current with needed information.
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
    /// Highlight this object (How Hmmm) when pressing scroll wheel / Space button
    /// </summary>
    private void HighlightInteractable()
    {
        //Highlight with Scroll wheel/Space button.
        //Should not need to be edited. 
        //Add On off if applicable...
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

        NameDisplay.ShowDisplayName_Static(interactableName);
    }


    

    /// <summary>
    /// Triggers Right/Left Click Highlight & Display Name
    /// For ease of not having to Raycast.
    /// </summary>
    private void OnMouseOver()
    {
        //Text Object Name of interactable

        //When I am moused over send info to Tooltip script?


        //Trigger OnLeftClick & On RightClick?

        //Trigger Display Name
        if(isItem || isInteractable)
        {
            DisplayName();
        }
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
