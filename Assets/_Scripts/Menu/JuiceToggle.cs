using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JuiceToggle : MonoBehaviour
{
    //1 Billboard (First Static, second for button adjustments)
    public static bool s_juiceBillboard = true;
    private bool juiceBillboard = true;
    //2Dialogue Typewriter
    private bool juiceEnableAnimation = true;

    //3Dialogue Animation
    private bool juiceEnableTypewriter = true;

    //4 Movement Animation
    public static bool s_juiceMovementAnime = true;
    private bool juiceMovementAnim = true;

    //5 Audio
    public static bool s_juiceSFX = true;
    private bool juiceSFX = true;

    //6 Name Display
    public static bool s_juiceNameDisplay = true;
    private bool juiceNameDisplay = true;

    //7 Spoken Display
    public static bool s_juiceSpokenDisplay = true;
    private bool juiceSpokenDisplay = true;

    //8 Cursor Click location
    public static bool s_juiceClickIndicator = true;
    private bool juiceClickIndicator = true;

    //9 Highilight Objects
    public static bool s_juiceHighlight = true;
    private bool juiceHighlight = true;



    [Header("Button setting")]
    [SerializeField] private Button applyButton;
    private bool changesToApply;


    private void Start()
    {
        //Keep Apply Button off before changes.
        applyButton.interactable = false;

        //Set all tick boxes to corespond to the value their static counterpart has.
        TickBoxSetup();
    }

    private void TickBoxSetup()
    {

    }

    public void TurnOnOffJuice(int chosenJuice)
    {
        switch (chosenJuice)
        {
            case 1:
                juiceBillboard = !juiceBillboard;
                break;

            case 2:
                juiceEnableTypewriter = !juiceEnableTypewriter;
                break;

            case 3:
                juiceEnableAnimation = !juiceEnableAnimation;
                break;

            case 4:
                juiceMovementAnim = !juiceMovementAnim;
                break;

            case 5:
                juiceSFX = !juiceSFX;
                break;

            case 6:
                juiceNameDisplay = !juiceNameDisplay;
                break;

            case 7:
                juiceSpokenDisplay = !juiceSpokenDisplay;
                break;

            case 8:
                juiceClickIndicator = !juiceClickIndicator;
                break;

            case 9:
                juiceHighlight = !juiceHighlight;
                break;
        }
        changesToApply = true;
    }

    private void Update()
    {
        if (changesToApply)
        {
            //Change has been done, so now you can apply the changes. Will not take into consideration if the settings are reset.
            applyButton.interactable = true;
            changesToApply = false;
        }
    }

    public void ResetForJuiceAdjustments(int sceneIndex)
    {
        s_juiceBillboard = juiceBillboard; //1

        Dialogue.enableTypewriter = juiceEnableTypewriter; //2

        Dialogue.enableAnimation = juiceEnableAnimation; //3

        s_juiceMovementAnime = juiceMovementAnim; //4

        s_juiceSFX = juiceSFX; //5

        s_juiceNameDisplay = juiceNameDisplay; //6

        s_juiceSpokenDisplay = juiceSpokenDisplay; //7

        s_juiceClickIndicator = juiceClickIndicator; //8

        s_juiceHighlight = juiceHighlight; //9


        applyButton.interactable = false;

        //Load scene shift
        //SceneManager.LoadScene(sceneIndex);
    }
}
