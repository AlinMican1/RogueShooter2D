using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSprite : MonoBehaviour
{

    [Header("Scripts")]
    PlayerMovement PlayerMovement_Script;

    [Header("variables")]
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement_Script = GameObject.FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

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
