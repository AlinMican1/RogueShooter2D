using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpPicker : MonoBehaviour
{
    PlayerXP playerXP_script;

    public void Start()
    {
        //Get playerXP script.
        playerXP_script = GameObject.FindObjectOfType<PlayerXP>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Find the collision of type XP and check the transform name.
        if (other.transform.tag == "XP")
        {
            
            if(other.transform.name == "1-Gem(Clone)")
            {
                playerXP_script.IncreaseXp(1);
            }
            if (other.transform.name == "2-Gem(Clone)")
            {
                playerXP_script.IncreaseXp(2);
            }
            if (other.transform.name == "5-Gem(Clone)")
            {
                playerXP_script.IncreaseXp(5);
            }
            if (other.transform.name == "10-Gem(Clone)")
            {
                playerXP_script.IncreaseXp(10);
            }
            //If the item is of XP-type in the collision destroy it.
            Destroy(other.gameObject);
        }


    }
}
