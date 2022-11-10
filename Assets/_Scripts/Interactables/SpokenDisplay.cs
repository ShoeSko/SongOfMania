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

    [Header("Test")]
    [SerializeField] private Transform lookAt;
    [SerializeField] private Vector3 offset;
    private Camera cam;

    private void Awake()
    {
        //Turn off both gameobjects.
        textName.gameObject.SetActive(false);
        textBackground.gameObject.SetActive(false);
        //Gives refrence to script easily accesible.
        s_spokenDisplay = this;

        cam = Camera.main;
    }

    private void Update()
    {
        Vector3 pos = cam.WorldToScreenPoint(lookAt.position + offset);

        if(transform.position != pos)
        {
            transform.position = pos;
        }
    }

    /// <summary>
    /// Can be easily called in any script
    /// Will Show Name Display
    /// </summary>
    public static void ShowDisplaySpoken_Static(string spokenText)
    {
        //IF there is no Dialogue displaying
        if (!Dialogue.isDialogue)
        {
            //To give better reference
            TextMeshProUGUI nameText = s_spokenDisplay.textName;
            RectTransform backgroundText = s_spokenDisplay.textBackground;

            nameText.gameObject.SetActive(true);
            backgroundText.gameObject.SetActive(true);

            s_spokenDisplay.textName.text = spokenText;

            float textPaddingSize = 4f;
            Vector2 backgroundSize = new Vector2(nameText.preferredWidth + textPaddingSize * 2f, nameText.preferredHeight + textPaddingSize * 2f);
            backgroundText.sizeDelta = backgroundSize;
            s_spokenDisplay.StartCoroutine(s_spokenDisplay.TimerToRemoveSpokenText());
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
