using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [Header("Billboard Customization")]
    [Tooltip("")]
    [SerializeField] private bool useBillboard = true;
    [Tooltip("")]
    [SerializeField] private bool useStaticBillboard;
    [Tooltip("0=No Restriction, 1=X only, 2=Y only, 3=Z only, 4=X&Y, 5=X&Z, 6= Y&Z, 7=XYZ")]
    [SerializeField] [Range(0, 6)] private int billboardRestrictionOption = 2;

    [Header("Needed Components")]
    //This refrences a Camera, if there is a camera shift in play, this MUST be changed as well. Make adaptable
    [SerializeField] private Camera cam;

    private void Start()
    {
        //Set start camera to main camera
        cam = Camera.main;
    }
    private void LateUpdate()
    {
        cam = Camera.main;

        if (useBillboard && JuiceToggle.s_juiceBillboard)
        {
            Billboarding();
        }
        else
        {
            //Do nothing!
        }
    }

    private void Billboarding()
    {
        if (!useStaticBillboard)
        {
            /*billboardChild.*/
            transform.LookAt(cam.transform);
        }
        else
        {
            transform.rotation = cam.transform.rotation;
        }

        //Goes through the different versions of billboarding
        switch (billboardRestrictionOption)
        {
            case 0:
                break;
            case 1:
                transform.rotation = Quaternion.Euler(-transform.rotation.eulerAngles.x, 0f, 0f);
                break;
            case 2:
                transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
                break;
            case 3:
                transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z);
                break;
            case 4:
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);
                break;
            case 5:
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0f, transform.rotation.eulerAngles.z);
                break;
            case 6:
                transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
                break;
            case 7:
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
                break;
        }
    }
}
