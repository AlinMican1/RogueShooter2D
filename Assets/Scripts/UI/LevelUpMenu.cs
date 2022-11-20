using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelUpMenu : MonoBehaviour
{

    public List<GameObject> buff_list;
    public List<GameObject> weapon_list;
    public List<GameObject> random_list;
    bool changeRandomNumber = true;
    public PlayerXP player_Xp_script;
    public string GetWeaponName;
    
    [SerializeField] Transform Weapon_List;
    int random_Card;
    PauseController pause;

    // Start is called before the first frame update
    void Start()
    {
        //Get the weapon List Card in the hierarchy
        Weapon_List = this.transform.GetChild(0).GetChild(3).GetChild(0).GetChild(0);
        //Setting All the lists to inactive at start of the game, only called when player has leveled up
        for (int i = 0; i < Weapon_List.childCount; i++){
            Weapon_List.GetChild(i).gameObject.SetActive(false);
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
            RandomNumber();
            //this stops the random number from changing.
            changeRandomNumber = false;
            //activates one of the cards in the list.
            Weapon_List.GetChild(RandomNumber()).gameObject.SetActive(true);
            

        }
    }

    public void clicked()
    {
        GetWeaponName = Weapon_List.GetChild(RandomNumber()).name;
        Weapon_List.GetChild(RandomNumber()).gameObject.SetActive(false);
        //when the card has been clicked we set it to inactive and allow our randomnumber function to genereate a new random number.
        changeRandomNumber = true;
        pause.PauseGame();
    }

    //Random numnber generator.
    public int RandomNumber()
    {
        if(changeRandomNumber == true)
        {
            random_Card = Random.Range(0, Weapon_List.childCount);
            changeRandomNumber = false;
        }
        return random_Card;
        
    }

    public string WeaponName()
    {
        return GetWeaponName;
    }
  
}
