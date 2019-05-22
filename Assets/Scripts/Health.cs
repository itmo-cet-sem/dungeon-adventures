using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float HungerTime = 5;  // через сколько секунд отнимаем еду
    public float PlayerHealth ; // переменная жизни (в данный момент)
    public float MaxHealth ; // максимально количество жизни
    public float Stamina  ; // переменная силы (сколько в данный момент)
    public float MaxStamina ; // максимальное количество силы
    public float Hungreed ; // переменная голода (в данный момент)
    public float MaxHungreed ; // максимальное количество еды

    Animator anim;                                                                              
    Movement Movement;
    bool isDead = false;
    float timer;

    void Awake()
    {
        anim = GetComponent<Animator>();
        Movement = GetComponent<Movement>();
    }



    void Start()
    {
        
        Stamina = MaxStamina; 
        Hungreed = MaxHungreed; 
        PlayerHealth = MaxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
     

        if (PlayerHealth >= MaxHealth)
        {
            PlayerHealth = MaxHealth;
        }
        if (Hungreed >= MaxHungreed)
        {
            Hungreed = MaxHungreed;
        }
        if (Stamina >= MaxStamina)
        {
            Stamina = MaxStamina;
        }

        if (PlayerHealth <= 0)
        { 
            PlayerHealth = 0; 
        }
        if (Stamina <= 0)
        { 
            Stamina = 0; 
        }

        if (Hungreed <= 0)
        { 
            Hungreed = 0;  
        }
        if (HungerTime >= HungerTime)
        {  
            HungerTime -= Time.deltaTime;
            if (HungerTime <= 0)
            {
                Hungreed -= 1; 
                HungerTime = 5;

                if (HungerTime <= 0 | Hungreed <= 0)
                {
                    PlayerHealth -= 1;
                    Stamina -= 1;
                    HungerTime = 5;
                }
            }
        }
      
        if (PlayerHealth <= 0 )
        {
            Death();
        }
    } 
    void Death()
    {
        isDead = true;
        HungerTime = 0f;
        PlayerHealth = 0;
        Hungreed = 0;
        Stamina = 0;
        Movement.enabled = false;
        
    }     
       
    void OnGUI()
    { 
        if (PlayerHealth > 0)
        {
            GUI.Label(new Rect(10, 80, 120, 20), "Жизни: " + PlayerHealth + "/" + MaxHealth); //вывод здоровья на экран
            GUI.Label(new Rect(10, 60, 120, 20), "Голод: " + Hungreed); //вывод голода на экран
            GUI.Label(new Rect(10, 40, 120, 20), "Сила: " + Stamina); //вывод силы на экран
        }

        if (isDead == true)
        {
            if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2) - 150f, 150f, 45f), "Начать с начала"))
            {
                SceneManager.LoadScene("cave");
            }

            if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2) - 100f, 150f, 45f), "В Меню"))
            {
               
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
