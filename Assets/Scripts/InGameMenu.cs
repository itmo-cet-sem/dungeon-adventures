using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public GameObject gbj;
    float timer;
    bool ispause;
    bool menuform;


    void Update()
    {
        Time.timeScale = timer;
        if (Input.GetKeyDown(KeyCode.Escape) && ispause == false)
        {
            ispause = true;
            menuform = true;
            SetTrue();

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && ispause == true)
        {
            ispause = false;
            menuform = false;
            SetFalse();

        }
        if (ispause == true)
        {
            timer = 0;
        }
        else if (ispause == false)
        {
            timer = 1f;
        }
    }

    public void SetTrue()
    {
        gbj.SetActive(true);


    }
    public void SetFalse()
    {
        gbj.SetActive(false);
    }

    public void OnGUI()
    {
        if (menuform == true)
        {
            Cursor.visible = true;
            GUI.Label(new Rect(10, (float)(Screen.height / 2) - 50f, 200f, 50f), "ИГРА ПОСТАВЛЕНА НА ПАУЗУ");

            if (GUI.Button(new Rect((float)(Screen.width / 2) + 100f, (float)(Screen.height / 2) - 100f, 150f, 45f), "Продолжить"))
            {
                ispause = false;
                menuform = false;
                timer = 0;
                Cursor.visible = false;
                SetFalse();
            }

            if (GUI.Button(new Rect((float)(Screen.width / 2) + 100f, (float)(Screen.height / 2) - 50f, 150f, 45f), "В Главное меню"))
            {
                ispause = false;
                timer = 0;
                SceneManager.LoadScene("Main_menu");

            }
            if (GUI.Button(new Rect((float)(Screen.width / 2) + 100f, (float)(Screen.height / 2) - 0f, 150f, 45f), "Выйти из игры"))
            {
                Debug.Log("Quit is done");
                Application.Quit();

            }
        }
    }
}
   
