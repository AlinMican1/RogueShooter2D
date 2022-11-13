using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Scripts")]
    PlayerLook Player_Look_Script;


    [Header("Player")]
    public float MovementSpeed = 5f;
    public Rigidbody2D Rb;
    bool Invulnerable;
    float DodgeCooldown = 1f;
    float NextDodge = 0f;
   
    
    Vector2 Move;

    
    private void Start()
    {
        //Invulnerable = false;
        //Find the script that is called PlayerLook on the attached Gameobject
        Player_Look_Script = GameObject.FindObjectOfType<PlayerLook>();
    }
    // Update is called once per frame
    void Update()
    {
        Move.x = Input.GetAxisRaw("Horizontal");
        Move.y = Input.GetAxisRaw("Vertical");
        //Constantly update player position
        GetPlayerPosition();
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            
            Dodge();
            //NextDodge = Time.time + DodgeCooldown;
        }
    }

    void FixedUpdate()
    {
        //Move the sprite around the map based on speed and input.
        Rb.MovePosition(Rb.position + Move * MovementSpeed * Time.fixedDeltaTime);
        Rb.rotation = Player_Look_Script.GetAngle();
    }

    public Vector2 GetPlayerPosition()
    {
        return Rb.position;
    }

    private void Dodge()
    {
        float DodgeSpeed = 10f;
        Rb.position = Rb.position + Move * DodgeSpeed * Time.fixedDeltaTime;
        
    }





}
