using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy_Bullet : MonoBehaviour
{
    public WeaponSystem weaponSystem_Script;
    public Rigidbody2D rb;
    Vector3 Lastvelocity;
    private float curSpeed;
    private Vector3 direction;
    private int curBounces;
    public int NumOfBounces;
    // Start is called before the first frame update
    void Start()
    {
        weaponSystem_Script = GameObject.FindObjectOfType<WeaponSystem>();
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        Lastvelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        
            if (curBounces >= NumOfBounces)
            {
                Destroy(gameObject);
            }
            curSpeed = Lastvelocity.magnitude;
            direction = Vector3.Reflect(Lastvelocity.normalized, collision.contacts[0].normal);
            rb.velocity = direction * Mathf.Max(curSpeed, 0f);
            curBounces++;

        
    }
}
