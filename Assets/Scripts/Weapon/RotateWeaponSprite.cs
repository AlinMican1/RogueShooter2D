using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWeaponSprite : MonoBehaviour
{
    PlayerLook playerLook_script;
    public List<SpriteRenderer> sprite = new List<SpriteRenderer>();

    public void Start()
    {
        playerLook_script = GameObject.FindObjectOfType<PlayerLook>();
    }
    // Update is called once per frame
    void Update()
    {
       

        for (int i = 0; i < sprite.Count; i++)
        {
            if (playerLook_script.GetAngle() < 89 && playerLook_script.GetAngle() > -89)
            {
                sprite[i].flipY = false;
            }
            else
            {
                sprite[i].flipY = true;
            }
        }
        
            
    }
}
