using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject aChild;
    public GameObject aSecondChild;
    
    public static bool s_IsPaused = false;

    public bool debugbool = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Pause()
    {
        aChild.SetActive(true);
        aSecondChild.SetActive(true);
        s_IsPaused = true;
        debugbool = true;
    }
    public void unPause()
    {
        s_IsPaused = false;
        debugbool = false;
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
