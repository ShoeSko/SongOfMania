using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    static bool isPaused = false;
    public void Pause()
    {
        isPaused = true;
    }
    public void unPause()
    {
        isPaused = false;
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
