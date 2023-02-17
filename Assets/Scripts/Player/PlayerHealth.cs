using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    bool HasBeenExecuted = false;
    [Header("Player variables")]
    public int maxHealth = 100;
    public int currentHealth;
    bool invulnerable = false;
    public bool playerDied = false;
    
    
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
            Debug.Log("Dead");
        }
        if(Input.GetKeyDown(KeyCode.E)){
            IncreaseHealth(15);
        }
        if (playerDied)
        {
            return;
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
        if (currentHealth <= 0 && HasBeenExecuted == false)
        {
            playerDied = true;
            HasBeenExecuted = true;

            print(timeScript.totalMinute);
            if (timeScript.totalMinute == 1)
            {
                GoldManager.gold = (goldScript.goldNum * 2) + GoldManager.gold;
                GoldManager.UpdateGold();
            }
            if (timeScript.totalMinute == 0)
            {
                GoldManager.gold = (goldScript.goldNum) + GoldManager.gold;
                GoldManager.UpdateGold();
            }

           
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
}
