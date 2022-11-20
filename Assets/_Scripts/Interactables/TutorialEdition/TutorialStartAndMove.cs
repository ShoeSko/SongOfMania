using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class TutorialStartAndMove : MonoBehaviour
{
    private Dialogue dialogueInstance;
    private bool hasActivated = false;

    [SerializeField] private float walkTimeNeeded = 2f;

    private void Start()
    {
        dialogueInstance = FindObjectOfType<Dialogue>();

        StartCoroutine(StartTheTalk());
    }

    IEnumerator StartTheTalk()
    {
        yield return new WaitForEndOfFrame();
        dialogueInstance.dialogueStart(1);
    }

    private void Update()
    {
        if(PlayerNavMesh.s_timesMoved > 4 && !hasActivated)
        {
            hasActivated = true;
            StartCoroutine(LearnTheWalk());
            ++TutorialManager.s_tutorialStage;
        }
    }

    IEnumerator LearnTheWalk()
    {
        hasActivated = true;
        yield return new WaitForSeconds(walkTimeNeeded);
        dialogueInstance.dialogueStart(5);
    }
}
