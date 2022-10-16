using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float BulletSpeed = 400f;
    public Rigidbody2D Rb;
    void Start()
    {
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

    }

}
