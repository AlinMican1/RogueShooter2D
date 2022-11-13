using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public WeaponSystem weaponSystem_Script;
   
    // Start is called before the first frame update
    public float BulletSpeed = 400f;
    public Rigidbody2D Rb;
    void Start()
    {
        weaponSystem_Script = GameObject.FindObjectOfType<WeaponSystem>();
        Destroy(gameObject, 2f);
        Rb.velocity = transform.right * BulletSpeed;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision)
        {
            Destroy(gameObject);
        }
        //get the collision with Create_Enemy script
        if(collision.gameObject.TryGetComponent<Create_Enemy>(out Create_Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(20);
        }
        
    }

}
