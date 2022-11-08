using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class printVariables : MonoBehaviour
{
    public string Itemname;
    public string failedPromt;
    public string SuccsessPromt;
    public string PickupPromt;
    
    public void printInfo()
    {
        print(Itemname); 
        print(failedPromt); 
        print(SuccsessPromt); 
        print(PickupPromt); 
    }
}
