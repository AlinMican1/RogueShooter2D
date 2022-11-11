using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Enemy : MonoBehaviour
{
    
    public int Health;
    public int DropXp;
    public int damage;
    public int speed;
    public Sprite gem;
    public Enemy_Object enemy_objects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void OnEnable()
    {
        EnemyConfig();
    }
    public virtual void EnemyConfig()
    {
         
        Health = enemy_objects.Health;
        DropXp = enemy_objects.DropXp;
        damage = enemy_objects.damage;
        speed = enemy_objects.speed;
        gem = enemy_objects.gem;
    }
}
