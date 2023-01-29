using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    float currentTime;
    public int start;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
       // currentTime = start * 60;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        float time = Time.time - startTime;

        string minute = ((int)time / 59).ToString();
        string second = (time % 59).ToString("N0");

        timerText.text = minute + ":" + second;

        if(minute == "1" && second == "0")
        {
            print("hi from salam");
        }
    }
}
