using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    //Variable for the gold
    [Header("variables")]
    public const string Gold = "gold";
    public static int gold = 0;

    //Function: Start is called before the first frame update
    void Start()
    {
        //Assign player prefs to get the gold amount that is saved.
        gold = PlayerPrefs.GetInt("gold");
    }

    //Function: Update the gold number based on how much gold the player has collected.
    public static void UpdateGold()
    {
        PlayerPrefs.SetInt("gold", gold);
        gold = PlayerPrefs.GetInt("gold");
        PlayerPrefs.Save();
    }
}
