using UnityEngine;
using UnityEngine.EventSystems;


public class ClickItem : MonoBehaviour
{
    private Inventory_Items items;
    public bool pickup;
    public bool use;

    private void Start()
    {
        items = GameObject.Find("Inventory").GetComponent<Inventory_Items>();
    }

    private void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(0)) {

            if (items.selectedItem != null)
            {
                if (items.UseItem(name, pickup))
                    Destroy(gameObject);
            }
            else if (!use && pickup)
            {
                items.PickUpItem(name);
                Destroy(gameObject);
            }
        }
        if (Input.GetMouseButtonDown(1))
            items.OnInspect(name);
    }

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    if (eventData.button == PointerEventData.InputButton.Left)
    //    {
    //        if (items.selectedItem != null)
    //        {
    //            if (items.UseItem(name, pickup))
    //                Destroy(gameObject);
    //        }
    //        else if (!use && pickup)
    //        {
    //            items.PickUpItem(name);
    //            Destroy(gameObject);
    //        }
    //    }

    //    if (eventData.button == PointerEventData.InputButton.Right)
    //    {
    //        items.OnInspect(name);
    //    }
    //}
}