using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float HungerTime = 5;  
    public float PlayerHealth ; 
    public float MaxHealth ; 
    public float Stamina  ; 
    public float MaxStamina ; 
    public float Hungreed ; 
    public float MaxHungreed ; 

    Animator anim;                                                                              
    Movement movement;
    bool isDead = false;
    public float timer = 1;

    void Awake()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<Movement>();
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
        if (movement.run == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Stamina -= 5;
                timer = 1;
            }
            if (timer <= 0 | Stamina <= 0)
            {
                timer = 0f;
            }
        }
        else if (movement.run == false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Stamina += 1;
                timer = 1;
            }
            if (timer <= 0 | Stamina >= MaxStamina)
            {
                timer = 0f;
                Stamina = MaxStamina;
            }
        }


        if (PlayerHealth <= 0 )
        {
            Death();
        }

        //Для тестирования
        if (Input.GetKeyDown(KeyCode.F) && PlayerHealth >= 0)
        {
            Death();
        }

        if (Input.GetKeyDown(KeyCode.G) && Hungreed >= 0)
        {
            Hungreed = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Hungreed += 30;
        }
    } 
    void Death()
    {
        isDead = true;
        HungerTime = 0f;
        PlayerHealth = 0;
        Hungreed = 0;
        Stamina = 0;
        movement.enabled = false;
        SceneManager.LoadScene("deathMenu");
    }     
       
    void OnGUI()
    { 
        if (PlayerHealth > 0)
        {
            GUI.Label(new Rect(10, 80, 120, 20), "Здоровье: " + PlayerHealth + "/" + MaxHealth);
            GUI.Label(new Rect(10, 60, 120, 20), "Сытость: " + Hungreed + "/" + MaxHungreed); 
            GUI.Label(new Rect(10, 40, 120, 20), "Сила: " + Stamina + "/" + MaxStamina); 
        }
    }
}
