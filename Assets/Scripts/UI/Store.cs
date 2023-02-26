using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    [System.Serializable] class StoreItem
    {
        //public Text Title;
        public Sprite Image;
        public int Price;
        public bool IsPurchased = false;
    }

    [SerializeField] List<StoreItem> StoreItemsList;
    [SerializeField] Animator NoGoldAnim;
    [SerializeField] Text GoldText;
    
    GameObject ItemTemplate;
    GameObject item;
    public Transform ShopPanel;
    Button buyBtn;
    private void Start()
    {
        GoldManager.gold = PlayerPrefs.GetInt("gold");
        print(GoldManager.gold);
        ItemTemplate = ShopPanel.GetChild(0).gameObject;
        GoldUI();
        for(int i = 0; i< StoreItemsList.Count; i++)
        {
            item = Instantiate(ItemTemplate, ShopPanel);
            //item.transform.GetChild(0).GetComponent<Text>().text = StoreItemsList[i].Title.text;
            item.transform.GetChild(1).GetComponent<Image>().sprite = StoreItemsList[i].Image;
            item.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = StoreItemsList[i].Price.ToString();
            buyBtn = item.transform.GetChild(3).GetComponent<Button>();
            buyBtn.interactable = !StoreItemsList[i].IsPurchased;
            buyBtn.AddEventListener(i, BtnClicked);
        }

        Destroy(ItemTemplate);
    }

    void BtnClicked(int itemIndex)
    {

        if(GoldManager.gold >= StoreItemsList[itemIndex].Price)
        {
            GoldManager.gold -= StoreItemsList[itemIndex].Price;
            GoldManager.UpdateGold();
            //buy item
            StoreItemsList[itemIndex].IsPurchased = true;
            //Disable button
            buyBtn = ShopPanel.GetChild(itemIndex).GetChild(3).GetComponent<Button>();
            buyBtn.interactable = false;
            buyBtn.transform.GetChild(0).GetComponent<Text>().text = "Purchased";
            GoldUI();
        }
        else
        {
            NoGoldAnim.SetTrigger("NoGold");
            Debug.Log("Not enough gold");
        }
       
    }
    void GoldUI()
    {
        GoldText.text = GoldManager.gold.ToString();
    }
}
