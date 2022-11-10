using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public Texture characterEurydice;
    public Texture characterOrpheus;
    public Texture characterUnknown;
    public RawImage characterRight;
    public RawImage characterLeft;

    public GameObject plateRight;
    public GameObject plateLeft;


    public TMP_Text displayText;
    public TMP_Text namePlateRight;
    public TMP_Text namePlateLeft;
    public GameObject dialogueParent;
    public GameObject TSVreader;

    public static bool isDialogue = false;

    public int nextLine;
    [HideInInspector]
    public Texture who;
    [HideInInspector]
    public string whoName;
    [HideInInspector]
    public bool whereLeft;
    [HideInInspector]
    public Texture otherTexture;
    [HideInInspector]
    public string otherName;
    private void Start()
    {
        displayText.text = "";
        namePlateLeft.text = "";
        namePlateRight.text = "";
        dialogueParent.gameObject.SetActive(false);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetMouseButtonDown(0) && isDialogue)
        {
            getDialogue(nextLine);
        }
    }

    public void getDialogue(int readLine)
    {
        
        otherTexture = null;
        if (readLine > -1)
        {
            isDialogue = true;
            dialogueParent.gameObject.SetActive(true);
            displayText.text = TSVreader.GetComponent<dialogueCSV>().myDialogueList.dialogue[readLine].promt;
            switch (TSVreader.GetComponent<dialogueCSV>().myDialogueList.dialogue[readLine].who)
            {
                case "Orpheus":
                    whoName = "Orpheus";
                    who = characterOrpheus;
                    break;
                case "Eurydice":
                    whoName = "Eurydice";
                    who = characterEurydice;
                    break;
                case "???":
                    whoName = "???";
                    who = characterUnknown;
                    break;
                case "no":
                    who = null;
                    break;
                default:
                    break;
            }
            switch (TSVreader.GetComponent<dialogueCSV>().myDialogueList.dialogue[readLine].Position)
            {
                case "L":
                    whereLeft = true;
                    break;
                case "R":
                    whereLeft = false;
                    break;
                default:
                    break;
            }
            switch (TSVreader.GetComponent<dialogueCSV>().myDialogueList.dialogue[readLine].partner)
            {
                case "Orpheus":
                    otherTexture = characterOrpheus;
                    break;
                case "Eurydice":
                    otherTexture = characterEurydice;
                    break;
                case "???":
                    otherTexture = characterUnknown;
                    break;
                case "No":
                    otherTexture = null;
                    break;
                default:
                    otherTexture = null;
                    break;
            }
            if (TSVreader.GetComponent<dialogueCSV>().myDialogueList.dialogue[readLine].next == 0)
            {
                nextLine = -1;
            }
            else
            {
                nextLine = readLine + 1;
            }
            displayImage();
        }
        else
        {
            dialogueFinished();
        }


    }

    //change image color based on who is talking; true == Left, false == right.
    void displayImage()
    {

        characterLeft.gameObject.SetActive(false);
        characterRight.gameObject.SetActive(false);
        plateRight.gameObject.SetActive(false);
        plateLeft.gameObject.SetActive(false);
        if (who != null)
        {
            if (whereLeft)
            {
                characterLeft.color = new Color(1f, 1f, 1f);
                characterLeft.gameObject.SetActive(true);
                plateLeft.gameObject.SetActive(true);
                namePlateLeft.text = whoName;
                characterLeft.texture = who;
            }
            else
            {
                characterRight.color = new Color(1f, 1f, 1f);
                characterRight.gameObject.SetActive(true);
                plateRight.gameObject.SetActive(true);
                namePlateRight.text = whoName;
                characterRight.texture = who;
            }

        }
        if (otherTexture != null)
        {

            if (whereLeft)
            {
                characterRight.color = new Color(.2f, .2f, .2f);
                characterRight.texture = otherTexture;
                characterRight.gameObject.SetActive(true);
                plateRight.gameObject.SetActive(false);
            }
            else
            {
                characterLeft.color = new Color(.2f, .2f, .2f);
                characterLeft.texture = otherTexture;
                characterLeft.gameObject.SetActive(true);
                plateLeft.gameObject.SetActive(false);
            }
        }

    }

    void dialogueStart()
    {
        dialogueParent.gameObject.SetActive(true);
    }
    void dialogueFinished()
    {
        StartCoroutine(DelayAfterDialogue());
        dialogueParent.gameObject.SetActive(false);
    }
    IEnumerator DelayAfterDialogue()
    {
        //Delay to prevent movement when finishing dialogue
        yield return new WaitForSeconds(.5f);
        isDialogue = false;
    }
}
