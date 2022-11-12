using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHider : MonoBehaviour
{
    private Rect ogPosition;
    [SerializeField] private RectTransform tempPosition;

    private bool isOff;

    private void Awake()
    {
        ogPosition = GetComponent<Rect>();

    }
    private void Update()
    {
        if (Dialogue.isDialogue && !isOff)
        {
            isOff = true;
            
        }
    }
}
