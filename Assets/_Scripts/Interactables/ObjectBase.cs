using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//It is a must that an interactable has a collider
[RequireComponent(typeof(Collider))]
public class ObjectBase : MonoBehaviour
{
    [Header("SpreadSheet")]
    public int sheet;
    public int row;
    //What is this object (Edited in child)
    public bool isItem { get; protected set; }
    public bool isInteractable { get; protected set; }
    public bool isNPC { get; protected set; }

    //Basic Variables all children will contain
    public string objectName { get; protected set; }
    public Dialogue dialogueInstance { get; protected set; }
    public itemCSVreader itemInstance { get; protected set; }
    public interactableCSVreader interactableInstace { get; protected set; }

    [Header("Hidden Variables")]
    private Material originalMaterial;
    [Tooltip("Whenever an object is clicked, tell the player")]

    [Header("OnRightClick Parameters")]
    [SerializeField] private float interactionRange;
    public Transform interactLocation { get; protected set; }
    public static ObjectBase s_objectInstance;
    //Activate the given function
    private bool activate = false;
    //In theory this one will be needed for Recieve as well. Make seperate function perhaps?
    [HideInInspector] public bool clickedObject;


    private void Start()
    {
        //To prevent that there is no instance of ObjectClass set. (May cause future issues
        s_objectInstance = this;


        if(!isNPC)
        {
            //Store current material for end of highligh
            originalMaterial = gameObject.GetComponent<MeshRenderer>().material;
        }

        if (transform.childCount > 0)
        {
            interactLocation = transform.GetChild(0).transform;
        }
        else
        {
            interactLocation = this.transform;
        }

        dialogueInstance = FindObjectOfType<Dialogue>();
        itemInstance = FindObjectOfType<itemCSVreader>();
        interactableInstace = FindObjectOfType<interactableCSVreader>();


        StartCoroutine(WaitForInformation());
    }

    IEnumerator WaitForInformation()
    {
        yield return new WaitForFixedUpdate();
        if (isItem)
        {
            objectName = itemInstance.myItemList.item[row].name;
        }
        else if (isInteractable)
        {
            objectName = interactableInstace.myInteractableList.interactable[row].name;
        }
        else
        {
            //Change to NPC later
            objectName = interactableInstace.myInteractableList.interactable[row].name;
        }
        //Find the dialogue script int scene (Should only be 1 per lvl)


    }

    private void Update()
    {
        HighlightInteractable();

        PlayerNearActivate();
        //Trigger for on activate stuff?
    }

    /// <summary>
    /// When you Right Click this object it will ...
    /// </summary>
    public virtual void OnActivate()
    {
        Debug.Log("Activated ");
        //Something Dialogue activation
    }

    /// <summary>
    /// When you Left Click this object it will prompt an observation dialog.
    /// </summary>
    public virtual void OnInspect()
    {
        //Something Dialogue Activation
    }

    /// <summary>
    /// When you 
    /// 1 Have item in inventory selected and click
    /// 2 Drag item in inventory over and release
    /// Do This.
    /// </summary>
    public virtual void OnRecieve()
    {
        //Condition of Inout + Item 
        //ApproachOnClick
        //Something Dialogue Activation
    }

    private void ApproachOnClick()
    {
        clickedObject = true;
        if (s_objectInstance != this)
        {
            s_objectInstance = this;
        }
    }

    public virtual void PlayerNearActivate()
    {
        //If not ClickedObject anymore, that means we do not want to activate it.
        if (clickedObject)
        {
            activate = true;
        }

        if (activate)
        {
            Collider[] locatePlayer = Physics.OverlapSphere(interactLocation.position, interactionRange);
            for (int i = 0; i < locatePlayer.Length; i++)
            {
                if (locatePlayer[i].GetComponent<PlayerNavMesh>())
                {
                    //Now you can activate either OnActive or OnRecieve
                    //IF (Static bool for holding item?)
                    //Else
                    //No longer activate after use.
                    activate = false;
                    OnActivate();
                }
            }
        }
    }

    private void OnDrawGizmosSelected() //Gizmo to represent attack range.
    {
        if (transform.childCount > 0)
        {
            interactLocation = transform.GetChild(0).transform;
        }
        else
        {
            interactLocation = this.transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactLocation.position,interactionRange);
    }

    /// <summary>
    /// Highlight this object when pressing scroll wheel / Space button
    /// Unless NPC
    /// </summary>
    private void HighlightInteractable()
    {
        //Trigger Highlight
        if (Input.GetMouseButton(2) || Input.GetKey(KeyCode.Space) && !isNPC && !Dialogue.isDialogue)
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
        NameDisplay.ShowDisplayName_Static(objectName);
    }



    /// <summary>
    /// Triggers Right/Left Click Highlight & Display Name
    /// For ease of not having to Raycast.
    /// </summary>
    private void OnMouseOver()
    {
        if (!Dialogue.isDialogue)
        {
            //Trigger OnInspect
            if (Input.GetMouseButton(1))
            {
                OnInspect();
            }

            //Setup for both On Active & OnRecieve
            if (Input.GetMouseButton(0))
            {
                ApproachOnClick();
            }


            //Trigger Display Name
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
