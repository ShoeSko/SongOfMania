using UnityEngine;
using TMPro;

public class NameDisplay : MonoBehaviour
{
    public static NameDisplay s_nameDisplay;

    [SerializeField] private Camera uiCamera;
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private RectTransform textBackground;

    [Range(0, 100)][SerializeField] private float displayPaddingX;
    [Range(45, 100)][SerializeField] private float displayPaddingY;

    public static bool s_nameDisplays;
    private void Awake()
    {
        //Turn off both gameobjects.
        textName.gameObject.SetActive(false);
        textBackground.gameObject.SetActive(false);
        //Gives refrence to script easily accesible.
        s_nameDisplay = this;
    }

    private void Update()
    {
        Vector2 localPoint;
        //Have display hover over cursor
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, uiCamera, out localPoint);
        //Pad cursor location to not cover cursor
        localPoint = new Vector2(localPoint.x + displayPaddingX, localPoint.y + displayPaddingY);
        transform.localPosition = localPoint;
    }

    /// <summary>
    /// Can be easily called in any script
    /// Will Show Name Display
    /// </summary>
    public static void ShowDisplayName_Static(string name)
    {
        //IF there is no Dialogue displaying
        if (!Dialogue.isDialogue && JuiceToggle.s_juiceNameDisplay)
        {
            //To give better reference
            TextMeshProUGUI nameText = s_nameDisplay.textName;
            RectTransform backgroundText = s_nameDisplay.textBackground;

            nameText.gameObject.SetActive(true);
            backgroundText.gameObject.SetActive(true);

            s_nameDisplay.textName.text = name;

            float textPaddingSize = 4f;
            Vector2 backgroundSize = new Vector2(nameText.preferredWidth + textPaddingSize *2f, nameText.preferredHeight + textPaddingSize *2f);
            backgroundText.sizeDelta = backgroundSize;

            s_nameDisplays = true;
        }
        else
        {
            HideDisplayName_Static();
        }
    }


    /// <summary>
    /// Can be easily called in any script
    /// Will Hide Name Display
    /// </summary>
    public static void HideDisplayName_Static()
    {
        s_nameDisplay.textName.gameObject.SetActive(false);
        s_nameDisplay.textBackground.gameObject.SetActive(false);
        s_nameDisplays = false;
    }
}
