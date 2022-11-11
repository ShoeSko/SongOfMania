using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//You Must have a NavMeshAgent to use this Script
[RequireComponent(typeof(NavMeshAgent), typeof(Collider))]
public class PlayerNavMesh : MonoBehaviour
{
    //Simple Refrence to the NavMeshAgent on the object that is to move(This case player)
    private NavMeshAgent playerNavAgent;

    [Header("Needed Components")]
    //This refrences a Camera, if there is a camera shift in play, this MUST be changed as well. Make adaptable
    [SerializeField] private Camera cam;

    public GameObject targetDestination;

    public Vector3 movingment;

    public static bool s_reachedLocation;
    public static int s_timesMoved;
    private void Awake()
    {
        playerNavAgent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        if (!Dialogue.isDialogue)
        {
            PlayerClick();
        }

        if (playerNavAgent.velocity.x > 0)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else if(playerNavAgent.velocity.x < 0)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        if (playerNavAgent.velocity != Vector3.zero)
        {
            GetComponentInChildren<Animator>().enabled = true;
        }
        else
        {
            GetComponentInChildren<Animator>().enabled = false;
        }
    }

    private void PlayerClick()
    {
        if (Input.GetMouseButton(0) && ObjectBase.s_objectInstance.clickedObject)
        {
            //Allow movement elsewhere, but has set movement to wanted locaiton
            ObjectBase.s_objectInstance.clickedObject = false;
            targetDestination.transform.position = ObjectBase.s_objectInstance.interactLocation.position;
            playerNavAgent.SetDestination(ObjectBase.s_objectInstance.interactLocation.position);
            s_timesMoved++;
        }
        else if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;

            if (Physics.Raycast(ray, out hitPoint))
            {
                targetDestination.transform.position = hitPoint.point;
                playerNavAgent.SetDestination(hitPoint.point);
            }
            s_timesMoved++;
        }
    }



    private void IsPlayerWalking()
    {
        
    }
}
