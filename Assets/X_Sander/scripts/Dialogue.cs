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
    public RawImage baground;

    public GameObject plateRight;
    public GameObject plateLeft;

    public Animator animator;

    public TMP_Text displayText;
    public TMP_Text namePlateRight;
    public TMP_Text namePlateLeft;
    public GameObject dialogueParent;
    public GameObject TSVreader;

    public static bool isDialogue = false;
    bool FirstPromt;
    public bool inputEnabeld;

    public int nextLine;

    [Header("jucing bools")]
    public static bool enableAnimation = true;
    public static bool enableTypewriter = true;
    public static bool enableVO = true;

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
        if (Input.GetKeyDown(KeyCode.RightArrow) && !inputEnabeld)
        {
            dialogueStart(nextLine);
            if (enableAnimation)
            {
                animator.ResetTrigger("EndDialogue");

            }

        }
        if (Input.GetMouseButtonDown(0) && isDialogue && inputEnabeld)
        {
            getDialogue(nextLine);
        }
    }

    public void getDialogue(int readLine)
    {

        otherTexture = null;
        if (readLine > -1)
        {
            var TSV = TSVreader.GetComponent<dialogueTSVreader>().myDialogueList.dialogue[readLine];
            string incomingText = TSV.promt;
            if (JuiceToggle.s_juiceSFX)
            {
                GetComponent<audioLibrary>().playAduio(TSV.who, TSV.audioEmotion);

            }
            isDialogue = true;
            dialogueParent.gameObject.SetActive(true);

            switch (TSV.who)
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
            switch (TSV.Position)
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

            switch (TSV.partner)
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

            if (!enableTypewriter)
            {
                displayText.text = incomingText;

                if (TSV.next == 0)
                {
                    nextLine = -1;
                }
                else
                {
                    nextLine = readLine + 1;
                }
            }
            else
            {

                if (GetComponent<typeWriterUi>().isGoing)
                {
                    GetComponent<typeWriterUi>().charIndex = incomingText.Length;
                    displayText.text = incomingText;

                    if (TSVreader.GetComponent<dialogueTSVreader>().myDialogueList.dialogue[readLine].next == 0)
                    {
                        nextLine = -1;
                    }
                    else
                    {
                        nextLine = readLine + 1;
                    }
                }
                else
                {
                    GetComponent<typeWriterUi>().run(incomingText, displayText);
                }
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
        FirstPromt = true;
        characterLeft.gameObject.SetActive(false);
        characterRight.gameObject.SetActive(false);
        plateRight.gameObject.SetActive(false);
        plateLeft.gameObject.SetActive(false);
        if (who != null)
        {

            if (whereLeft)
            {
                if (enableAnimation && FirstPromt)
                {
                    animator.SetBool("FadeLeft", true);
                    animator.SetBool("FadeRight", false);
                }
                characterLeft.color = new Color(1f, 1f, 1f);
                characterLeft.rectTransform.localScale = new Vector3(4f, 6f);
                characterLeft.gameObject.SetActive(true);
                plateLeft.gameObject.SetActive(true);
                namePlateLeft.text = whoName;
                characterLeft.texture = who;
            }
            else
            {
                if (enableAnimation && FirstPromt)
                {
                    animator.SetBool("FadeRight", true);
                    animator.SetBool("FadeLeft", false);
                }
                characterRight.color = new Color(1f, 1f, 1f);
                characterRight.rectTransform.localScale = new Vector3(4f, 6f);
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
                characterRight.rectTransform.localScale = new Vector3(3.6f, 5.4f);
                characterRight.texture = otherTexture;
                characterRight.gameObject.SetActive(true);
                plateRight.gameObject.SetActive(false);
            }
            else
            {
                characterLeft.color = new Color(.2f, .2f, .2f);
                characterLeft.rectTransform.localScale = new Vector3(3.6f, 5.4f);
                characterLeft.texture = otherTexture;
                characterLeft.gameObject.SetActive(true);
                plateLeft.gameObject.SetActive(false);
            }
        }

    }

    public void dialogueStart(int readline)
    {
        nextLine = readline;
        StartCoroutine(DelayBeforeDialogue());

        if (enableAnimation && !FirstPromt)
        {
            GetComponent<Animator>().enabled = true;
            //baground fade in
            animator.SetTrigger("StartDialogue");
            getDialogue(nextLine);
        }
        else
        {
            GetComponent<Animator>().enabled = false;
            getDialogue(nextLine);
        }
        dialogueParent.gameObject.SetActive(true);
    }
    void dialogueFinished()
    {
        inputEnabeld = false;
        animator.SetTrigger("EndDialogue");
        animator.SetBool("FadeRight", false);
        animator.SetBool("FadeLeft", false);
        StartCoroutine(DelayAfterDialogue());
        FirstPromt = false;
    }
    IEnumerator DelayBeforeDialogue()
    {
        inputEnabeld = true;
        yield return new WaitForSeconds(1f);
    }
    IEnumerator DelayAfterDialogue()
    {
        //Delay to prevent movement when finishing dialogue
        yield return new WaitForSeconds(.5f);
        dialogueParent.gameObject.SetActive(false);
        isDialogue = false;
    }
}
