using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public static int s_tutorialStage = 0;
    public static bool s_leftBedroom = false;
    public static bool s_finishedTutorial = false;

    private void Awake()
    {
        s_tutorialStage = 0;
        s_leftBedroom = false;
        s_finishedTutorial = false;
    }

    private void Update()
    {
        ToTheCredits();
    }

    private void ToTheCredits()
    {
        if (!Dialogue.isDialogue && s_finishedTutorial)
        {
            SceneManager.LoadScene(2);
        }
    }
}
