using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpokenDisplay : MonoBehaviour
{
    public static SpokenDisplay s_spokenDisplay;

    [SerializeField] private Camera uiCamera;
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private RectTransform textBackground;
    private Transform playerLocation;
    public float textVisiblityTime = 4f;

    [Range(0, 100)] [SerializeField] private float displayPaddingX;
    [Range(45, 100)] [SerializeField] private float displayPaddingY;
    private void Awake()
    {
        //Turn off both gameobjects.
        textName.gameObject.SetActive(false);
        textBackground.gameObject.SetActive(false);
        //Gives refrence to script easily accesible.
        s_spokenDisplay = this;

        playerLocation = FindObjectOfType<PlayerNavMesh>().transform;
    }

    private void Update()
    {
        Vector2 localPoint;
        //Have display hover over cursor
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), playerLocation.position, uiCamera, out localPoint);
        //Pad cursor location to not cover cursor
        localPoint = new Vector2(localPoint.x + displayPaddingX, localPoint.y + displayPaddingY);
        transform.localPosition = localPoint;
    }

    /// <summary>
    /// Can be easily called in any script
    /// Will Show Name Display
    /// </summary>
    public static void ShowDisplaySpoken_Static(string name)
    {
        //IF there is no Dialogue displaying
        if (!Dialogue.isDialogue)
        {
            //To give better reference
            TextMeshProUGUI nameText = s_spokenDisplay.textName;
            RectTransform backgroundText = s_spokenDisplay.textBackground;

            nameText.gameObject.SetActive(true);
            backgroundText.gameObject.SetActive(true);

            s_spokenDisplay.textName.text = name;

            float textPaddingSize = 4f;
            Vector2 backgroundSize = new Vector2(nameText.preferredWidth + textPaddingSize * 2f, nameText.preferredHeight + textPaddingSize * 2f);
            backgroundText.sizeDelta = backgroundSize;
            
        }
    }


    IEnumerator TimerToRemoveSpokenText()
    {
        yield return new WaitForSeconds(textVisiblityTime);
        HideDisplaySpoken_Static();
    }

    /// <summary>
    /// Can be easily called in any script
    /// Will Hide Name Display
    /// </summary>
    public static void HideDisplaySpoken_Static()
    {
        s_spokenDisplay.textName.gameObject.SetActive(false);
        s_spokenDisplay.textBackground.gameObject.SetActive(false);
    }
}
