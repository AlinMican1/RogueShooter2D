using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Enemy : MonoBehaviour
{
    //Variables for enemy attributes.
    [Header("variables")]
    public int Health;
    int DropXp;
    public int damage;
    int speed;
    int range;
    float attackCooldown;
    public GameObject gemModel;
    float distance;
    public bool Enemydead = false;
    public Timer Time_script;
    bool IncreaseAtt = false;
    //Variables for scripts.
    [Header("Scripts")]
    public Enemy_Object enemy_objects;
    public DropXp Drop_Xp_Script;
    public PlayerMovement playerMovement_script;
    public PlayerHealth playerHealth_script;
    public SpawnPoint SpawnPointEnemy;



    //Function: Start is called before the first frame update
    void Start()
    {
        //Assign all the variables to their assigned scripts, so we can access them.
        Drop_Xp_Script = this.GetComponent<DropXp> ();
        playerMovement_script = GameObject.FindObjectOfType<PlayerMovement>();
        playerHealth_script = GameObject.FindObjectOfType<PlayerHealth>();
        Time_script = GameObject.FindObjectOfType<Timer>();
        SpawnPointEnemy = GameObject.FindObjectOfType<SpawnPoint>();

    }

    //Function: Used only when the object is active.
    public virtual void OnEnable()
    {
        EnemyConfig();
    }
    //Function:  Update is called once per frame
    public void Update()
    {
        //Assign a variable distance, to check the distance of the enemy position and player position.
        distance = Vector3.Distance(playerMovement_script.GetPlayerPosition(), this.transform.position);

        //If the distance is less than the enemy range, then using the "TakeDamage(damage)" function, the player takes damage. 
        if (distance <= range)
        {
            playerHealth_script.TakeDamage(damage);
        }
        BuffEnemy();
       
    }

    //Function: Assign the enemy attributes from the enemy_object scriptable object.
    public virtual void EnemyConfig()
    {
         
        Health = enemy_objects.Health;
        DropXp = enemy_objects.DropXp;
        damage = enemy_objects.damage;
        speed = enemy_objects.speed;
        range = enemy_objects.range;
        attackCooldown = enemy_objects.attackCooldown;
    }

    //Function: Allows the enemy to take damage based on the weapon damage.
    public void TakeDamage(int damageAmount)
    {
        //The health variable decreases based on 
        Health -= damageAmount;
        //If the health is below or equal to zero desactivate the enemy object, and drop XP.
        if(Health <= 0)
        {
            Enemydead = true;
            gameObject.SetActive(false);
            SpawnPointEnemy.ActiveOfBasicEnemies -= 1;

            
            Drop_Xp_Script.DropItem(enemy_objects.DropXp);
           
        }
    }

    //Function: Track enemy position and return it as a Vector3 type.
    public Vector3 enemyPosition()
    {
        Vector3 position = transform.position;
        return position;
    }
    //Function: keep track of enemy health and return it as a integer.
    public int EnemyHealth()
    {
        return Health;
    }
    
    void BuffEnemy()
    {
        if(int.Parse(Time_script.minute) == 2 && float.Parse(Time_script.second) == 30 && IncreaseAtt == false)
        {
            damage += 5;
            Health += 50;
            IncreaseAtt = true;
           
        }
        
        IncreaseAtt = false;
        
        if (float.Parse(Time_script.minute) == 4 && IncreaseAtt == false)
        {
            Health += 50;
            IncreaseAtt = true;
            damage += 5;
        }
    }

   
}
