using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public Texture characterEurydice;
    public Texture characterOrpheus;
    public RawImage characterRight;
    public RawImage characterLeft;

    public GameObject plateRight;
    public GameObject plateLeft;


    public TMP_Text displayText;
    public TMP_Text namePlateRight;
    public TMP_Text namePlateLeft;
    public GameObject dialogueParent;
    public GameObject TSVreader;

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
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            getDialogue(nextLine);
        }
    }

    void getDialogue(int readLine)
    {
        otherTexture = null;
        if (readLine > -1)
        {
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

                default:
                    break;
            }
            switch (TSVreader.GetComponent<dialogueCSV>().myDialogueList.dialogue[readLine].Position)
            {
                case "Left":
                    whereLeft = false;
                    break;
                case "Right":
                    whereLeft = true;
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
                case "no":
                    otherTexture = null;
                    break;
                default:
                    otherTexture = null;
                    break;
            }
            nextLine = TSVreader.GetComponent<dialogueCSV>().myDialogueList.dialogue[readLine].next - 2;
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
        dialogueParent.gameObject.SetActive(false);
    }

}
