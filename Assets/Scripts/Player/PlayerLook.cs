using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("Scripts")]
    PlayerMovement Move_Player_Script;

    [Header("Variables")]
    public Camera Cam;

    [SerializeField] float angle;
    Vector2 MousePosition;
    // Start is called before the first frame update
    void Start()
    {
        Cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        //Find the script that is called PlayerMovement on the attached Gameobject
        Move_Player_Script = GameObject.FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        MousePosition = Cam.ScreenToWorldPoint(Input.mousePosition);
        
    }

    private void FixedUpdate()
    {
        //Get the Direction the player is facing
        Vector2 Direction = MousePosition - Move_Player_Script.GetPlayerPosition();
        //Calculate the angle that between starting vector and directional vector
        angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
    
    }

    public float GetAngle()
    {
        return angle;
    }
}
