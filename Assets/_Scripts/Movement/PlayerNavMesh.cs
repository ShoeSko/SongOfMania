using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//You Must have a NavMeshAgent to use this Script
[RequireComponent(typeof(NavMeshAgent), typeof(Billboard))]
public class PlayerNavMesh : MonoBehaviour
{
    //Simple Refrence to the NavMeshAgent on the object that is to move(This case player)
    private NavMeshAgent playerNavAgent;

    [Header("Needed Components")]
    //This refrences a Camera, if there is a camera shift in play, this MUST be changed as well. Make adaptable
    [SerializeField] private Camera cam;

    public GameObject targetDestination;

    [SerializeField] private GameObject billboardChild;

    private void Awake()
    {
        playerNavAgent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        PlayerClick();
    }

    private void PlayerClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10000))
            {
                Debug.Log(hit.transform.gameObject.name);
            }
        }

        if (Input.GetMouseButton(0) && ObjectBase.s_clickedObject)
        {
            //Allow movement elsewhere, but has set movement to wanted locaiton
            ObjectBase.s_clickedObject = false;
            targetDestination.transform.position = ObjectBase.s_interactLocation.position;
            playerNavAgent.SetDestination(ObjectBase.s_interactLocation.position);
        }
        else if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;

            if(Physics.Raycast(ray, out hitPoint))
            {
                targetDestination.transform.position = hitPoint.point;
                playerNavAgent.SetDestination(hitPoint.point);
            }
        }
    }



    private void IsPlayerWalking()
    {
        if(playerNavAgent.velocity != Vector3.zero)
        {
            //Player is now walking
        }
    }
}
