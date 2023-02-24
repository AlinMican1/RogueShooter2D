using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public Text timerText;
    float currentTime;
    public int start;
    private float startTime;
    private PlayerHealth playerHealthScript;
    private bool stopTimer = false;
    public GoldScript goldScript;
    public int totalMinute = 0;

    // Start is called before the first frame update
    void Start()
    {
       // currentTime = start * 60;
        startTime = Time.time;
        playerHealthScript = GameObject.FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stopTimer)
            return;
        
        float time = Time.time - startTime;

        string minute = ((int)time / 60).ToString();
        string second = (time % 60).ToString("f1");

        timerText.text = minute + ":" + second;
        
        //check if player has died
        if (playerHealthScript.PlayerDied())
        {
            stopTimer = true;
            totalMinute = int.Parse(minute);
            print("here" + totalMinute);

        }
        if (minute == "1" && second == "0")
        {
            return;
        }
    }
    
}
