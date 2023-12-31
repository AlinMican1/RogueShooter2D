using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    LevelUpMenu levelUpMenu_script;
    
    public int currentWeapon = 0;
    string WeaponName;

    
    // Start is called before the first frame update
    void Start()
    {
        levelUpMenu_script = GameObject.FindObjectOfType<LevelUpMenu>();
        //Set all the weapons except the starting weapon to false at the start.
        for (int i = 1; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(false);
        }
        WeaponName = this.transform.GetChild(0).name;

    }

    // Update is called once per frame
    void Update()
    {
        //if the weapon name in the hierarchy is the same as the card weapon name then set the currentWeapon be the i counter.
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (this.transform.GetChild(i).name == levelUpMenu_script.GetWeaponName)
            {
                currentWeapon = i;
                SwitchWeapons(currentWeapon);

            }

        }
    }

    
    public void SwitchWeapons(int index)
    {
        //The weapon that has the index in the hierarchy set it to true, otherwise set all other weapons to false.
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (i == index)
            {
                this.transform.GetChild(i).gameObject.SetActive(true);
                WeaponName = this.transform.GetChild(i).name;
            }
            else
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public string GetWeaponName()
    {
        return WeaponName;
    }
}
