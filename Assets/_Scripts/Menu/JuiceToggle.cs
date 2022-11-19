using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JuiceToggle : MonoBehaviour
{
    //1 Billboard (First Static, second for button adjustments)
    public static bool s_juiceBillboard = true;
    public bool juiceBillboard = true;
    //Dialogue (Speed?)
    //Dialogue (Animations?)
    //4 Movement Animation
    public static bool s_juiceMovementAnime = true;
    public bool juiceMovementAnim = true;
    //Audio

    //8 Cursor Click location
    public static bool s_juiceClickIndicator = true;
    public bool juiceClickIndicator = true;


    [Header("Button setting")]
    [SerializeField] private Button applyButton;
    private bool changesToApply;
    private void Start()
    {
        //Keep Apply Button off before changes.
        applyButton.interactable = false;
    }

    public void TurnOnOffJuice(int chosenJuice)
    {
        switch (chosenJuice)
        {
            case 1:
                juiceBillboard = !juiceBillboard;
                break;

            case 4:
                juiceMovementAnim = !juiceMovementAnim;
                break;

            case 8:
                juiceClickIndicator = !juiceClickIndicator;
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
        s_juiceBillboard = juiceBillboard;

        s_juiceMovementAnime = juiceMovementAnim;

        s_juiceClickIndicator = juiceClickIndicator;


        applyButton.interactable = false;

        //Load scene shift
        //SceneManager.LoadScene(sceneIndex);
    }
}
