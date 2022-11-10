using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class basicMainMenu : MonoBehaviour
{
    public void startDemo()
    {
        SceneManager.LoadScene(1);
    }
    public void endSCreen()
    {
        SceneManager.LoadScene(2);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
