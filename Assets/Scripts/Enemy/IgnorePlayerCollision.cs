using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePlayerCollision : MonoBehaviour
{
    //Function: To prevent the collision between the player and enemy, this is done to prevent the enemy pushing the player.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Ignores the player layer and enemy layer.
        Physics2D.IgnoreLayerCollision(10, 30);
    }
}
