using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class basicMainMenu : MonoBehaviour
{
    public GameObject aChild;
    public GameObject aSecondChild;
    public GameObject logo;
    private bool onMainMenu;
    private bool subMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            // goes back to main menu or quits
            if (onMainMenu)
            {
                exitGame();
            }
            if (subMenu)
            {
                GoToMain();
                aChild.SetActive(true);
                aSecondChild.SetActive(false);
                logo.SetActive(true);
            }
        }

    }
    public void GoToMain()
    {
        subMenu = false;
        onMainMenu = true;
    }
    public void GoToSub()
    {
        subMenu = true;
        onMainMenu = false;
    }
    public void startDemo()
    {
        Debug.Log("loading game");

        SceneManager.LoadScene(1);
    }
    public void endSCreen()
    {
        Debug.Log("loading endsceene");
        SceneManager.LoadScene(2);
    }
    public void exitGame()
    {
        Debug.Log("exit game");
        Application.Quit();
    }
    public void mainMenu()
    {
        Debug.Log("loading mainmenu");

        SceneManager.LoadScene(0);
    }
    public void testingGrounds()
    {
        SceneManager.LoadScene(3);
    }
}
