using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeanPuzzleComplete : MonoBehaviour
{
    public static bool s_seanPuzzleDone;

    private void Awake()
    {
        s_seanPuzzleDone = false;
    }

    private void Start()
    {
        StartCoroutine(DialogueDelayStart());
    }

    IEnumerator DialogueDelayStart()
    {
        yield return new WaitForSeconds(0.2f);


        Dialogue dialogueInstance = FindObjectOfType<Dialogue>();

        dialogueInstance.dialogueStart(1);

    }
    private void Update()
    {
        EndTheMisery();
    }

    private void EndTheMisery()
    {
        if (!Dialogue.isDialogue && SeanTrophyTable.s_doneWithPuzzles)
        {
            SceneManager.LoadScene(0);
        }
    }
}