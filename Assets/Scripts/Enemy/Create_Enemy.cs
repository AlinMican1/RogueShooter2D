using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Enemy : MonoBehaviour
{
    
    int Health;
    int DropXp;
    int damage;
    int speed;
    int range;
    float attackCooldown;

    
    public GameObject gemModel;
    public Enemy_Object enemy_objects;
    public DropXp Drop_Xp_Script;
    public PlayerMovement playerMovement_script;
    public PlayerHealth playerHealth_script;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        Drop_Xp_Script = this.GetComponent<DropXp> ();
        playerMovement_script = GameObject.FindObjectOfType<PlayerMovement>();
        playerHealth_script = GameObject.FindObjectOfType<PlayerHealth>();


    }

    // Update is called once per frame
    public virtual void OnEnable()
    {
        EnemyConfig();
    }
    public void Update()
    {
        distance = Vector3.Distance(playerMovement_script.GetPlayerPosition(), this.transform.position);

        if (distance <= range)
        {
            playerHealth_script.TakeDamage(damage);
        }
       
    }
    public virtual void EnemyConfig()
    {
         
        Health = enemy_objects.Health;
        DropXp = enemy_objects.DropXp;
        damage = enemy_objects.damage;
        speed = enemy_objects.speed;
        range = enemy_objects.range;
        attackCooldown = enemy_objects.attackCooldown;
    }

    public void TakeDamage(int damageAmount)
    {
        Health -= damageAmount;
        if(Health <= 0)
        {
            gameObject.SetActive(false);
            
            Drop_Xp_Script.DropItem(enemy_objects.DropXp);
           
        }
    }

    public Vector3 enemyPosition()
    {
        Vector3 position = transform.position;
        return position;
    }

    

   
}
