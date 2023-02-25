using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public Text Price_text;
    public Color MarkIt;
    //public GameObject StoreManager;

    private void Update()
    {
        //Price_text.text = "Gold: " + StoreManager.GetComponent<StoreManagement>().ShopItems[2, ItemID].ToString();
    }
}
