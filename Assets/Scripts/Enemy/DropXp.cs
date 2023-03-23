using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropXp : MonoBehaviour
{
    //Variables for the gem model and get enemy script.
    [Header("variables")]
    public GameObject[] gemModel;
    public Create_Enemy create_Enemy_script;
    void Start()
    {
        //Assign all the variables to their assigned scripts, so we can access them.
        create_Enemy_script = this.GetComponent<Create_Enemy>();
    }

   

    //Function: Drop XP based on the XP number the enemy is assigned to.
    public void DropItem(int Xp)
    {
        //Based on the XP number when the enemy dies, instantiate a gameObject at the location of where the enemy died.
        if(Xp == 2)
        {
            GameObject gems = Instantiate(gemModel[1], create_Enemy_script.enemyPosition() + new Vector3(0, 0, -1), Quaternion.identity);
        }
        if (Xp == 1)
        {
            GameObject gems = Instantiate(gemModel[0], create_Enemy_script.enemyPosition() + new Vector3(0,0,-1), Quaternion.identity);
        }
        if (Xp == 5)
        {
            GameObject gems = Instantiate(gemModel[2], create_Enemy_script.enemyPosition() + new Vector3(0, 0, -1), Quaternion.identity);
        }
        if (Xp == 10)
        {
            GameObject gems = Instantiate(gemModel[3], create_Enemy_script.enemyPosition() + new Vector3(0, 0, -1), Quaternion.identity);
        }
        if (Xp == 20)
        {
            GameObject gems = Instantiate(gemModel[4], create_Enemy_script.enemyPosition() + new Vector3(0, 0, -1), Quaternion.identity);
        }

    }
}
