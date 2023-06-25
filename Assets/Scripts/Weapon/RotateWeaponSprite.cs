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
        //Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = rotation;

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
