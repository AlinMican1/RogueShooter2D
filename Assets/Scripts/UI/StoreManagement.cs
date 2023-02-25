using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StoreManagement : MonoBehaviour
{

    public int[,] ShopItems = new int[5, 5];
    
    
    public Text goldText;
   
    // Start is called before the first frame update
    void Start()
    {
        GoldManager.gold = PlayerPrefs.GetInt("gold");
        //Load Gold
        goldText.text = GoldManager.gold.ToString();
        

        //Item ID
        ShopItems[1, 1] = 1;
        ShopItems[1, 2] = 2;
        ShopItems[1, 3] = 3;
        ShopItems[1, 4] = 4;

        //Prices
        ShopItems[2, 1] = 20;
        ShopItems[2, 2] = 20;
        ShopItems[2, 3] = 30;
        ShopItems[2, 4] = 40;

        //Mark it
        ShopItems[3, 1] = 0;
        ShopItems[3, 2] = 0;
        ShopItems[3, 3] = 0;
        ShopItems[3, 4] = 0;
    }

    public void BuyItem()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("BuyItem").GetComponent<EventSystem>().currentSelectedGameObject;
        if(PlayerPrefs.GetInt("gold") >= ShopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID] && ShopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID] == 0)
        {
            GoldManager.gold -= ShopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            goldText.text = GoldManager.gold.ToString();
            GoldManager.UpdateGold();
            ShopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            
        }


    }
}
