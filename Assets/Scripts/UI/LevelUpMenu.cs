using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelUpMenu : MonoBehaviour
{

    bool changeRandomNumber = true;
    bool changeRandomNumber2 = true;
    public PlayerXP player_Xp_script;
    public string GetWeaponName;
    public string GetBuffName;
    
    
    [SerializeField] Transform Weapon_List;
    [SerializeField] Transform Buff_List;
    int random_Weapon;
    int random_Buff;
    PauseController pause;

    // Start is called before the first frame update
    void Start()
    {
        GetBuffName = "default";
        //Get the weapon List Card in the hierarchy
        Weapon_List = this.transform.GetChild(0).GetChild(3).GetChild(0).GetChild(0);

        //Get the Buffs List Card from the hierarchy
        Buff_List = this.transform.GetChild(0).GetChild(3).GetChild(1).GetChild(0);
        //Setting All the lists to inactive at start of the game, only called when player has leveled up


        for (int i = 0; i < Weapon_List.childCount; i++){
            Weapon_List.GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < Buff_List.childCount; i++)
        {
            Buff_List.GetChild(i).gameObject.SetActive(false);
        }

        player_Xp_script = GameObject.FindObjectOfType<PlayerXP>();
        pause = GameObject.FindObjectOfType<PauseController>();



    }

    // Update is called once per frame
    public void Update()
    {
        
        //If we have leveled up we activate a random card in the list.
        if (player_Xp_script.LevelUp() == true)
        {
            RandomNumber_Weapons();
            RandomNumber_Buffs();
            //this stops the random number from changing.
            changeRandomNumber = false;
            changeRandomNumber2 = false;
            //activates one of the cards in the list.
            Weapon_List.GetChild(RandomNumber_Weapons()).gameObject.SetActive(true);
            
            Buff_List.GetChild(RandomNumber_Buffs()).gameObject.SetActive(true);
            
        }
    }

    public void clicked()
    {
        
        GetWeaponName = Weapon_List.GetChild(RandomNumber_Weapons()).name;
       
        Weapon_List.GetChild(RandomNumber_Weapons()).gameObject.SetActive(false);
        Buff_List.GetChild(RandomNumber_Buffs()).gameObject.SetActive(false);
        


        //when the card has been clicked we set it to inactive and allow our randomnumber function to genereate a new random number.
        changeRandomNumber = true;
        pause.PauseGame();
    }

    public void clicked_Buff()
    {
        
        GetBuffName = Buff_List.GetChild(RandomNumber_Buffs()).name;
       
        Buff_List.GetChild(RandomNumber_Buffs()).gameObject.SetActive(false);
        Weapon_List.GetChild(RandomNumber_Weapons()).gameObject.SetActive(false);
        

        //when the card has been clicked we set it to inactive and allow our randomnumber function to genereate a new random number.
        changeRandomNumber2 = true;
        pause.PauseGame();
    }

    //Random number generator.
    public int RandomNumber_Weapons()
    {
        if(changeRandomNumber == true)
        {
            random_Weapon = Random.Range(0, Weapon_List.childCount);
            changeRandomNumber = false;
        }
        return random_Weapon;
        
    }

    public int RandomNumber_Buffs()
    {
        if (changeRandomNumber2 == true)
        {
            random_Buff = Random.Range(0, Buff_List.childCount);
            changeRandomNumber2 = false;
        }
        return random_Buff;

    }

  
}
