using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    float timer;
    bool ispause;
    bool menuform;

    void Update()
    {
        Time.timeScale = timer;
        if (Input.GetKeyDown(KeyCode.Escape) && ispause == false)
        {
            ispause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && ispause == true)
        {
            ispause = false;
        }
        if (ispause == true)
        {
            timer = 0;
            menuform = true;

        }
        else if (ispause == false)
        {
            timer = 1f;
            menuform = false;

        }
    }
    public void OnGUI()
    {
        if (menuform == true)
        {
            Cursor.visible = true;
            if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2) - 150f, 150f, 45f), "Продолжить"))
            {
                ispause = false;
                timer = 0;
                Cursor.visible = false;
            }
          
            if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2) - 100f, 150f, 45f), "В Меню"))
            {
                ispause = false;
                timer = 0;
                SceneManager.LoadScene("Main_menu");

            }
            if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2) - 50f, 150f, 45f), "Выйти из игры"))
            {
                Debug.Log("Quit is done");
                Application.Quit();

            }
        }
    }
}
