using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBasicFollow : MonoBehaviour
{
    public static bool changeCamLoc = false;
    [SerializeField] private Vector3 newCamPosition;
    private void Start()
    {
        changeCamLoc = false;
    }

    private void Update()
    {
        if (changeCamLoc)
        {
            transform.position = newCamPosition;
        }
    }
    #region Old Follow
    /*
    public static Transform target;
    [SerializeField] private Vector3 offset;

    private void Start()
    {
        target = FindObjectOfType<PlayerNavMesh>().transform;
    }
    // Update is called once per frame
    void Update()
    {
        //transform.position = target.position + offset;
        transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z + offset.z);
    }*/
    #endregion
}
