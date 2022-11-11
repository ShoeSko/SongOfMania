using UnityEngine;
using UnityEngine.EventSystems;


public class ClickInventory : MonoBehaviour, IPointerClickHandler
{
    private Inventory_Items items;

    private void Start()
    {
        items = GameObject.Find("Inventory").GetComponent<Inventory_Items>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (items.selectedItem == null)
                items.SelectItem(int.Parse(name));
            else
                items.UseItem(int.Parse(name));
        }

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            items.OnInspect(int.Parse(name));
        }
    }
}