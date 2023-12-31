using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    bool HasBeenExecuted = false;
    [Header("Player variables")]
    public int maxHealth = 100;
    public int currentHealth;
    bool invulnerable = false;
    public bool playerDied = false;
    int time_multiplier = 100000000;
    
    
    
    [Header("Scripts")]
    public HealthBar healthbar;
    public GoldScript goldScript;
    public Timer timeScript;
    
   
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        goldScript = GameObject.FindObjectOfType<GoldScript>();
        timeScript = GameObject.FindObjectOfType<Timer>();
        GoldManager.gold = PlayerPrefs.GetInt("gold");


    }

    // Update is called once per frame
    void Update()
    {
        //Testing purposes
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
        
        if (PlayerDied())
        {
           
            playerDied = true;

            
            StartCoroutine(executeLate());
  
        }
        print(GoldManager.gold);

    }
    //Added to get the right value of the variable.
    IEnumerator executeLate()
    {
        yield return new WaitForSeconds(0.5f);
        Score(time_multiplier);
        DisplayDeathScreen();

    }

    //Function: Call it to multiply the amount of gold by the amount of minutes survived by the player.
    public void Score(int multiply)
    {
        if (multiply >= 0 && multiply <=5 && HasBeenExecuted == false)
        {
            GoldManager.gold += (goldScript.goldNum);
            GoldManager.UpdateGold();
            HasBeenExecuted = true;
        }
        else if (multiply >= 5 && multiply <= 10 && HasBeenExecuted == false)
        {
            GoldManager.gold = (goldScript.goldNum * 2) + GoldManager.gold;
            GoldManager.UpdateGold();
            HasBeenExecuted = true;
        }

        else if (multiply >= 10 && multiply <= 20 && HasBeenExecuted == false)
        {
            GoldManager.gold = (goldScript.goldNum * 3) + GoldManager.gold;
            GoldManager.UpdateGold();
            HasBeenExecuted = true;
        }
        else if (multiply >= 20 && HasBeenExecuted == false)
        {
            GoldManager.gold = (goldScript.goldNum * 4) + GoldManager.gold;
            GoldManager.UpdateGold();
            HasBeenExecuted = true;
        }
    }
    //take damage from current health 
    public void TakeDamage(int damage)
    {
        if(invulnerable == false)
        {
            currentHealth -= damage;
            healthbar.SetHealth(currentHealth);
            StartCoroutine(DamageTaken());
        }
    }

    IEnumerator DamageTaken()
    {
        invulnerable = true;
        yield return new WaitForSeconds(0.5f);
        invulnerable = false;
    }
    //Check if player Health is less/equal to 0, return true.
    public bool PlayerDied()
    {
        if (currentHealth <= 0)
        {
            
            time_multiplier = timeScript.totalMinute;
           
            
            return true;
        }
        return false;
    }
    //Increase health points depending.
    public void IncreaseHealth(int health)
    {
        //Don't do anything
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        //Don't go over the maxhealth;
        else if(currentHealth + health >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        //Otherwise just add the health to the currenthealth.
        else
        {
            currentHealth += health;
        }
        healthbar.SetHealth(currentHealth);
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    void DisplayDeathScreen()
    {
      
        SceneManager.LoadScene("DeathScreen");
       
    }
}
