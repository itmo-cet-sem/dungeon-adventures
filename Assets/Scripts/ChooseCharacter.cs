using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacter : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            Player1.SetActive(true);
            Player2.SetActive(false);
            Player3.SetActive(false);
                     
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            Player1.SetActive(false);
            Player2.SetActive(true);
            Player3.SetActive(false);

        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            Player1.SetActive(false);
            Player2.SetActive(false);
            Player3.SetActive(true);

        }
    }
}