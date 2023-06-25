using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Default_Bullet : MonoBehaviour
{
    private
    // Start is called before the first frame update
    void Start()
    {
        //Destroy default bullet after 2 seconds.
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
