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


    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
            if(lifeTime <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        if (createForce)
        {
            Rb.AddForce(transform.forward * thurst);
            createForce = false;
        }
        if (shouldExplode)
        {
            Collider[] colliders = GetOverlappers();
            foreach(Collider hit in colliders)
            {
                Rigidbody2D Rb = hit.GetComponent<Rigidbody2D>();
                
            }
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        shouldExplode = true;
        Instantiate(explosion, transform.position, transform.rotation);
    }

    Collider[] GetOverlappers(){
        return Physics.OverlapSphere(transform.position, radius);
    }
}
