using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class typeWriterUi : MonoBehaviour
{
    public int charIndex;
    public float typeSpeed;
    static string text;
    public bool isGoing;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            charIndex = text.Length;
        }
    }
    public void run(string textToType, TMP_Text textLable)
    {
        text = textToType;
        print("starting");
        charIndex = 0;
        StartCoroutine(TypeText(textToType, textLable));
    }
    private IEnumerator TypeText(string textToType, TMP_Text textLable)
    {
        isGoing = true;
        float t = 0;
        charIndex = 0;
        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime * typeSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLable.text = textToType.Substring(0, charIndex);

            yield return null;

        }

        #region ducttape
        var dialogueScript = GetComponent<Dialogue>();
        var dialogueTSVreader = GetComponent<dialogueTSVreader>();
        if (dialogueTSVreader.myDialogueList.dialogue[dialogueScript.debugReadline].next == 0)
        {
            dialogueScript.nextLine = -1;
        }
        else
        {
            dialogueScript.nextLine = dialogueScript.debugReadline + 1;
        }
        #endregion

        isGoing = false;
    }
}
