using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class Store : MonoBehaviour
{
    [System.Serializable] 
    public class StoreItem
    {
        public Text Title;
        public Sprite Image;
        public int Price;
        public bool IsPurchased = false;

        public StoreItem(StoreItem item)
        {
            Title = item.Title;
            Image = item.Image;
            Price = item.Price;
            IsPurchased = item.IsPurchased;
        }
    }

    [SerializeField] List<StoreItem> StoreItemsList;
    [SerializeField] Animator NoGoldAnim;
    [SerializeField] Text GoldText;
    
    
    GameObject ItemTemplate;
    GameObject item;
    public Transform ShopPanel;
    Button buyBtn;
    StoreItem a;
    private void Start()
    {
        
        GoldManager.gold = PlayerPrefs.GetInt("gold");
        print(GoldManager.gold);
        ItemTemplate = ShopPanel.GetChild(0).gameObject;
        GoldUI();
        
        for(int i = 0; i< StoreItemsList.Count; i++)
        {
            a = StoreItemsList[i];
            SaveSystem.SaveToJSON(StoreItemsList[i],StoreItemsList.Count);
            
            //print(SaveSystem.LoadFromJsonBoolean(StoreItemsList[i]));

            item = Instantiate(ItemTemplate, ShopPanel);
            item.transform.GetChild(0).GetComponent<Text>().text = StoreItemsList[i].Title.text;
            item.transform.GetChild(1).GetComponent<Image>().sprite = StoreItemsList[i].Image;
            item.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = StoreItemsList[i].Price.ToString();
            /*if (StoreItemsList[i].IsPurchased != SaveSystem.LoadFromJsonBoolean(StoreItemsList[i]))
            {
                print("hello");
                print(StoreItemsList[i]);
                buyBtn = ShopPanel.GetChild(i).GetChild(3).GetComponent<Button>();
                buyBtn.interactable = false;
                buyBtn.transform.GetChild(0).GetComponent<Text>().text = "Purchased";
            }*/
            
            buyBtn = item.transform.GetChild(3).GetComponent<Button>();
            buyBtn.interactable = !StoreItemsList[i].IsPurchased;
            buyBtn.AddEventListener(i, BtnClicked);
            
            
        }

        Destroy(ItemTemplate);
    }

    void BtnClicked(int itemIndex)
    {
        
        if (GoldManager.gold >= StoreItemsList[itemIndex].Price) //&& SaveSystem.LoadFromJsonBoolean() == false)
        {
            GoldManager.gold -= StoreItemsList[itemIndex].Price;
            GoldManager.UpdateGold();
            //buy item
            StoreItemsList[itemIndex].IsPurchased = true;
            //Disable button
            buyBtn = ShopPanel.GetChild(itemIndex).GetChild(3).GetComponent<Button>();
            buyBtn.interactable = false;
            buyBtn.transform.GetChild(0).GetComponent<Text>().text = "Purchased";
            //SaveSystem.SaveToJSON(StoreItemsList[itemIndex]);
            GoldUI();
        }
        
        
        
        else
        {
            //SaveSystem.SaveToJSON(StoreItemsList[itemIndex]);
            NoGoldAnim.SetTrigger("NoGold");
            Debug.Log("Not enough gold");
        }
       
    }
    void GoldUI()
    {
        GoldText.text = GoldManager.gold.ToString();
    }

    

    public static class SaveSystem
    {
        
        /*public static void SaveItem(StoreItem item)
        {
            BinaryFormatter formatter  = new BinaryFormatter();
            //Find a path to save the data;
            string path = Application.persistentDataPath + "/itemData.txt";
            FileStream stream = new FileStream(path, FileMode.Create);
            StoreItem data = new StoreItem(item);

            //Put the data on the formatter
            formatter.Serialize(stream,data);

            //Close file
            stream.Close();

        }*/

        /*public static StoreItem LoatItem()
        {
            string path = Application.persistentDataPath + "/itemData.txt";
            //check if file Exists
            if (File.Exists(path)){
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                //Decrypt the data into readable data.
                formatter.Deserialize(stream);

                //Store the data as a store Item;
                StoreItem data = formatter.Deserialize(stream) as StoreItem;
                stream.Close();
                return data;
            }
            else
            {
                Debug.Log("Not Found");
                return null;
            }
        }*/

        public static void SaveToJSON(StoreItem item, int count)
        {
            string json = null;
            
            for (int i =0; i< count; i++)
            {
                
                json = JsonUtility.ToJson(item, true);
               
            }
            
            string filePath = Application.persistentDataPath + "/ItemData.json";
            Debug.Log(filePath);
            File.WriteAllText(filePath, json);

        }
          
           

        public static bool LoadFromJsonBoolean(StoreItem item)
        {
            string json = File.ReadAllText(Application.dataPath + "/ItemData.json");
            StoreItem data = JsonUtility.FromJson<StoreItem>(json);
            //item.Title = data.Title;
            //item.Price = data.Price;
            //item.IsPurchased = data.IsPurchased;
            return data.IsPurchased;

            
        }
        public static string LoadFromJsonString(StoreItem item)
        {
            string json = File.ReadAllText(Application.dataPath + "/ItemData.json");
            StoreItem data = JsonUtility.FromJson<StoreItem>(json);
            //item.Title = data.Title;
            //item.Price = data.Price;
            //item.IsPurchased = data.IsPurchased;
            return data.Title.ToString();


        }
    }
    

    
}
