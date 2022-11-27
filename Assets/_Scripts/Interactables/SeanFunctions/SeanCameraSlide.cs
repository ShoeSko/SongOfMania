using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeanCameraSlide : MonoBehaviour
{
    [SerializeField] private Transform playerToFollow;
    [SerializeField] private float leftBound;
    [SerializeField] private float rightBound;
    private void Update()
    {
        if(transform.position.x < rightBound && transform.position.x > leftBound)
        {
            SideToSide();
        }
        else if(transform.position.x > rightBound)
        {
            ToTheLeft();
        }
        else if(transform.position.x < leftBound)
        {
            ToTheRight();
        }
    }

    private void SideToSide()
    {
        transform.position = new Vector3(playerToFollow.position.x, transform.position.y, transform.position.z);
    }

    private void ToTheLeft()
    {
        if (playerToFollow.position.x < transform.position.x)
        {
            transform.position = new Vector3(playerToFollow.position.x, transform.position.y, transform.position.z);
        }
    }

    private void ToTheRight()
    {
        if (playerToFollow.position.x > transform.position.x)
        {
            transform.position = new Vector3(playerToFollow.position.x, transform.position.y, transform.position.z);
        }
    }
}
