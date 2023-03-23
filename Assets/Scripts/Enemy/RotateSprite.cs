using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSprite : MonoBehaviour
{
    //Variables for scripts.
    [Header("Scripts")]
    PlayerMovement PlayerMovement_Script;

    //Variable of type SpriteRenderer to get the enemy sprite.
    [Header("variables")]
    public SpriteRenderer sprite;
    
    
    //Function: Start is called before the first frame update
    void Start()
    {
        //Assign the variable to their assigned scripts, so we can access them.
        PlayerMovement_Script = GameObject.FindObjectOfType<PlayerMovement>();
    }

    //Function: Update is called once per frame
    void Update()
    {
        //Based on the player x-axis coordinate and the enemy x-axis coordinate, flip the sprite on its x-axis to face the player.
        if (PlayerMovement_Script.GetPlayerPosition().x < this.transform.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }

   
}
