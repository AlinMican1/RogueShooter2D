using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropXp : MonoBehaviour
{
    public GameObject[] gemModel;
    public Create_Enemy create_Enemy_script;
    public PlayerMovement playerMovement_script;
    void Start()
    {
        //Get the enemy script
        create_Enemy_script = this.GetComponent<Create_Enemy>();
    }

   

    //Drop item the correct gem based on mob XP
    public void DropItem(int Xp)
    {
        if(Xp == 2)
        {
            GameObject gems = Instantiate(gemModel[1], create_Enemy_script.enemyPosition(), Quaternion.identity);
        }
        if (Xp == 1)
        {
            GameObject gems = Instantiate(gemModel[0], create_Enemy_script.enemyPosition(), Quaternion.identity);
        }
        if (Xp == 5)
        {
            GameObject gems = Instantiate(gemModel[2], create_Enemy_script.enemyPosition(), Quaternion.identity);
        }
        if (Xp == 10)
        {
            GameObject gems = Instantiate(gemModel[3], create_Enemy_script.enemyPosition(), Quaternion.identity);
        }

    }
}
