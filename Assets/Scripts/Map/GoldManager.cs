using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    public const string Gold = "gold";

    public static int gold = 0;

    // Start is called before the first frame update
    void Start()
    {
        gold = PlayerPrefs.GetInt("gold");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void UpdateGold()
    {
        PlayerPrefs.SetInt("gold", gold);
        gold = PlayerPrefs.GetInt("gold");
        PlayerPrefs.Save();
    }
}
