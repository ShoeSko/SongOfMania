using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject aChild;
    public GameObject aSecondChild;
    public GameObject aThirdChild;
    
    public static bool s_IsPaused = false;

    public bool debugbool = false;

    private bool onMainMenu;
    [HideInInspector]
    public  bool subMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !s_IsPaused)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && s_IsPaused)
        {
            // goes back to main menu or quits
            if (onMainMenu)
            {
                unPause();                
            }
            if (subMenu)
            {
                OpenMainPause();
                aChild.SetActive(true);
                aThirdChild.SetActive(false);
            }

        }
    }
    public void SubMenu()
    {
        subMenu = true;
        onMainMenu = false;
    }
    public void OpenMainPause()
    {
        subMenu = false;
        onMainMenu = true;
    }
    public void Pause()
    {
        onMainMenu = true;
        aChild.SetActive(true);
        aSecondChild.SetActive(true);
        s_IsPaused = true;
        debugbool = true;
    }
    public void unPause()
    {
        s_IsPaused = false;
        debugbool = false;
        aChild.SetActive(false);
        aSecondChild.SetActive(false);
        onMainMenu = false;
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
