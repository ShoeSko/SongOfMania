using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items
{
    public enum ItemType 
    { 
        Stool, 
        Key, 
        Brokenlyre, 
        Rake, 
        LyreString, 
        Lyre
    }
    public ItemType itemType;
    public int amount;

}
