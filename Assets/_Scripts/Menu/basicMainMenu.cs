using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class basicMainMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Q))
        {
            mainMenu();
        }
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
    public void mainMenu()
    {
        Debug.Log("loading mainmenu");

        SceneManager.LoadScene(0);
    }
}
