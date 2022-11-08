using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{

    private NavMeshAgent playerNavAgent;

    [SerializeField] private Camera cam;
    public GameObject targetDestination;
    //[SerializeField] private Transform movePositionTransform;



    private void Awake()
    {
        playerNavAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Sett Destination of NavmeshAgent
        //navMeshAgent.destination = movePositionTransform.position;
        PlayerClick();
    }

    private void PlayerClick()
    {
        if (Input.GetMouseButton(0))
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
