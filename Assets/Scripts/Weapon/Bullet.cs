using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public WeaponSystem weaponSystem_Script;
    
    // Start is called before the first frame update
    public float BulletSpeed = 2f;
    public Rigidbody2D Rb;
    void Start()
    {
        
        weaponSystem_Script = GameObject.FindObjectOfType<WeaponSystem>();
        
        //Add recoil to the direction of the bullet.
        Rb.velocity = (transform.right+new Vector3(weaponSystem_Script.AddRecoil(), weaponSystem_Script.AddRecoil(), 0))  * BulletSpeed;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
         //Don't collide with XP
         if (collision.gameObject.tag == "XP")
         {
              Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
         }
         //Ignore bullet layer
        Physics2D.IgnoreLayerCollision(9, 9);
        Physics2D.IgnoreLayerCollision(9, 7);
        Physics2D.IgnoreLayerCollision(9, 11);
        //get the collision with Create_Enemy script
        if (collision.gameObject.TryGetComponent<Create_Enemy>(out Create_Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(weaponSystem_Script.damage);
            
        }
        

    }

}
