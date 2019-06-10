using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void InMainMenu()
    {
        Debug.Log("In main menu is done");
        SceneManager.LoadScene("Main_menu");
    }
    public void QuitGame()
    {
        Debug.Log("Quit is done");
        Application.Quit();
    }
}
   
