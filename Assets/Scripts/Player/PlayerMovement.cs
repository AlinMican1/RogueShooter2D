using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float MovementSpeed = 5f;
    public Rigidbody2D Rb;
    Vector2 Move;

    // Update is called once per frame
    void Update()
    {
        Move.x = Input.GetAxisRaw("Horizontal");
        Move.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        //Move the sprite around the map based on speed and input.
        Rb.MovePosition(Rb.position + Move * MovementSpeed * Time.fixedDeltaTime);
    }
}
