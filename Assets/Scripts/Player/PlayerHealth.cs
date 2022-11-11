using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player variables")]
    public int maxHealth = 100;
    public int currentHealth;
    
    [Header("Scripts")]
    public HealthBar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
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
    }
    //take damage from current health 
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

    }
    //Check if player Health is less/equal to 0, return true.
    public bool PlayerDied()
    {
        if (currentHealth <= 0)
        {
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
