using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive_Bullet : MonoBehaviour
{
    public Rigidbody2D Rb;
    public bool createForce = true;
    public bool shouldExplode = false;
    public float lifeTime = 5f;

    public float power = 2.5f;
    public float radius = 2f;
    public float thurst = 2f;

    public GameObject explosion;

    public Collider[] collider;

    public WeaponSystem weaponSystem_Script;
    public Rigidbody2D rb;
    Vector3 Lastvelocity;

    // Start is called before the first frame update
    /*void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }*/
    void Start()
    {
        weaponSystem_Script = GameObject.FindObjectOfType<WeaponSystem>();
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    

    // Update is called once per frame
    void Update()
    {
        if (!shouldExplode)
        {
            Destroy(gameObject, 3f);
        }
        /*if(lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
            if(lifeTime <= 0)
            {
                Destroy(gameObject);
            }
        }*/
    }

    private void FixedUpdate()
    {
        if (shouldExplode)
        {
            Collider[] colliders = GetOverlappers();
            foreach(Collider hit in colliders)
            {
                Rigidbody2D Rb = hit.GetComponent<Rigidbody2D>();
                
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        shouldExplode = true;
        GameObject explode = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(explode, 1f);
    }

    Collider[] GetOverlappers(){
        return Physics.OverlapSphere(transform.position, radius); 
    }
}

