using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText;
    float currentTime;
    public int start;
    public float totalSecond = 0;
    private float startTime;
    private PlayerHealth playerHealthScript;
    private bool stopTimer = false;
    public GoldScript goldScript;
    public int totalMinute = 0;
    public Create_Enemy create_Enemy_script;
    public bool AddHealth = false;
    public string second;
    public string minute;
    public ObjectPoolEnemies PoolEnemies_script;
    //Save Time
    public const string MINUTE = "minute";
    public const string SECOND = "second";

    // Start is called before the first frame update
    void Start()
    {
       // currentTime = start * 60;
        startTime = Time.time;
        playerHealthScript = GameObject.FindObjectOfType<PlayerHealth>();
        create_Enemy_script = GameObject.FindObjectOfType<Create_Enemy>();
        PoolEnemies_script = GameObject.FindObjectOfType<ObjectPoolEnemies>();

    }

    // Update is called once per frame
    void Update()
    {
        //print(create_Enemy_script.Health);
        if (stopTimer)
            return;
        
        float time = Time.time - startTime;

        minute = ((int)time / 60).ToString();
        second = (time % 60).ToString("f1");

        timerText.text = minute + ":" + second;
        
        
        //check if player has died
        if (playerHealthScript.PlayerDied())
        {
            stopTimer = true;
            totalMinute = int.Parse(minute);
            totalSecond = float.Parse(second);
            print(totalSecond);
            StateNameController.minute = totalMinute;
            StateNameController.second = totalSecond;
        }
        Buffenemy();
        


    }

    void Buffenemy()
    {
        if (float.Parse(second) == 10 )
        {
            print("hi1");
            for (int i = 0; i <= PoolEnemies_script.basicEnemies.Count; i++)
            {
                print("hi2");
                if (PoolEnemies_script.basicEnemies[i].activeInHierarchy == true)
                {
                    
                    create_Enemy_script.Health += 100;
                }
            }
            
            
        }
    }
    void DisplayDeathScreen()
    {
        SceneManager.LoadScene("DeathScreen");
    }


}
