using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCursorNotice : MonoBehaviour
{
    public static bool s_hoveringOverInventory;

    #region Prevent Inventory + Movement Clash
    private void OnMouseEnter()
    {
        s_hoveringOverInventory = true;
        Debug.Log("Entered Inventory");
    }
    private void OnMouseOver()
    {
        Debug.Log("Over Inventory");
    }
    private void OnMouseExit()
    {
        s_hoveringOverInventory = false;
        Debug.Log("Left Inventory");
    }
    #endregion
}
