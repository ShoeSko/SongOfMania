using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCursorNotice : MonoBehaviour
{
    public static bool s_hoveringOverInventory;

    #region Prevent Inventory + Movement Clash
    public void CursorOverInventory()
    {
        s_hoveringOverInventory = true;
        Debug.Log("Over Inventory");
    }
    public void CursorLeftInventory()
    {
        s_hoveringOverInventory = false;
        Debug.Log("Left Inventory");
    }
    #endregion
}
